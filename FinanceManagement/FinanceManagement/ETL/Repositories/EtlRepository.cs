namespace FinanceManagement.ETL.Repositories
{
    using System.Collections.ObjectModel;
    using System.Data;
    using DataAccess;
    using Mappers;
    using Models;

    public class EtlRepository : DataContext, IEtlRepository
    {
        public ImportFileBatch CreateImportFileBatch(ImportFileType importFileType, string fileName)
        {
            //TODO Handle errors
            var importFileBatch = new ImportFileBatch();
            var mapper = new ImportFileBatchDataMapper();
            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.CreateImportFileBatch))
            {
                AddParameter(command, DbType.Int32, "ImportFileTypeId", importFileType.ImportFileTypeId);
                AddParameter(command, DbType.String, "ImportFileName", fileName);
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        importFileBatch = mapper.MapSingle(reader);
                    }
                }
            }

            importFileBatch.ImportFileType = importFileType;
            return importFileBatch;
        }

        public Collection<ImportFileType> GetActiveImportFileTypes()
        {
            var mapper = new ImportFileTypeDataMapper();

            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetActiveImportFiles))
            {
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    return mapper.MapAll(reader);
                }
            }
        }

        public void ExecutePostLoadProcedure(ImportFileBatch importFileBatch)
        {
            if (string.IsNullOrEmpty(importFileBatch.ImportFileType.PostLoadProcedure))
            {
                return;
            }

            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(importFileBatch.ImportFileType.PostLoadProcedure))
            {
                AddParameter(command, DbType.Int32, "ImportFileBatchId", importFileBatch.ImportFileBatchId);
                Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateImportFileBatchRecordCount(ImportFileBatch importFileBatch, int batchRecordCount)
        {
            SetSqlConnection();
            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.UpdateImportFileBatchRecordCount))
            {
                AddParameter(command, DbType.Int16, "ImportFileBatchId", importFileBatch.ImportFileBatchId);
                AddParameter(command, DbType.Int32, "BatchRecordCount", batchRecordCount);
                Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateImportFileBatchStatus(ImportFileBatch importFileBatch, ImportFileBatchStatus importFileBatchStatus)
        {
            SetSqlConnection();
            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.UpdateImportFileBatchStatus))
            {
                AddParameter(command, DbType.Int16, "ImportFileBatchId", importFileBatch.ImportFileBatchId);
                AddParameter(command, DbType.Int32, "ImportFileBatchStatusId", (short)importFileBatchStatus);
                Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
