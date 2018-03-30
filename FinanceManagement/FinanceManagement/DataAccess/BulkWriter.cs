namespace FinanceManagement.DataAccess
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.SqlClient;
    using ETL.Models;

    public abstract class BulkWriter<T> : DataContext
    {
        protected BulkWriter()
        {
            SetSqlConnection();
        }

        public abstract ImportFileBatch ImportFileBatch { get; }
        protected abstract Collection<SqlBulkCopyColumnMapping> GetMappings();

        public void Execute(Collection<T> sourceData)
        {
            Connection.Open();
            using (var sqlBulkCopy = new SqlBulkCopy((SqlConnection) Connection))
            {
                sqlBulkCopy.DestinationTableName = ImportFileBatch.ImportFile.StagingTable;
                foreach (var mapping in GetMappings())
                {
                    sqlBulkCopy.ColumnMappings.Add(mapping);
                }

                var sourceDataAsDataTable = ConvertSourceToDataTable(sourceData);
                sqlBulkCopy.WriteToServer(sourceDataAsDataTable);
            }
        }

        private DataTable ConvertSourceToDataTable(IEnumerable<T> sourceData)
        {
            var sourceDataTable = new DataTable();
            if (ImportFileBatch != null) sourceDataTable = AddStagingColumns(sourceDataTable);

            var classType = typeof(T);

            foreach (var property in classType.GetProperties())
                sourceDataTable.Columns.Add(property.Name, property.PropertyType);

            var batchRowId = 1;

            foreach (var T in sourceData)
            {
                var sourceDataRow = sourceDataTable.NewRow();
                sourceDataRow[0] = ImportFileBatch.ImportFileBatchId;
                sourceDataRow[1] = batchRowId++;

                foreach (var property in classType.GetProperties()) sourceDataRow[property.Name] = property.GetValue(T);

                sourceDataTable.Rows.Add(sourceDataRow);
            }

            return sourceDataTable;
        }

        private static DataTable AddStagingColumns(DataTable sourceDataTable)
        {
            sourceDataTable.Columns.Add("ImportFileBatchId", typeof(short));
            sourceDataTable.Columns.Add("BatchRowId", typeof(short));
            return sourceDataTable;
        }
    }
}
