namespace FinanceManagement.ETL.Repositories
{
    using System.Collections.ObjectModel;
    using System.Data;
    using DataAccess;
    using Mappers;
    using Models;

    public class EtlRepository : DataContext, IEtlRepository
    {
        public ImportFileBatch CreateImportFileBatch(ImportFile importFile, string fileName)
        {
            var importFileBatch = new ImportFileBatch();
            var mapper = new ImportFileBatchMapper();
            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.CreateImportFileBatch))
            {
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        importFileBatch = mapper.MapSingle(reader);
                    }
                }
            }

            return importFileBatch;
        }

        public Collection<ImportFile> GetActiveImportFiles()
        {
            var mapper = new ImportFileMapper();

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

        public void ExecutePostLoadProcedure(ImportFileBatch importFileBatch, int importFileBatchId)
        {
            if (string.IsNullOrEmpty(importFileBatch.ImportFile.PostLoadProcedure))
            {
                return;
            }

            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(importFileBatch.ImportFile.PostLoadProcedure))
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
            using (var command = CreateSqlCommand(importFileBatch.ImportFile.PostLoadProcedure))
            {
                AddParameter(command, DbType.Int16, "ImportFileBatchId", importFileBatch.ImportFileBatchId);
                AddParameter(command, DbType.Int32, "BatchRecordCount", batchRecordCount);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateImportFileBatchStatus(ImportFileBatch importFileBatch, ImportFileBatchStatus importFileBatchStatus)
        {
            SetSqlConnection();
            using (Connection)
            using (var command = CreateSqlCommand(importFileBatch.ImportFile.PostLoadProcedure))
            {
                AddParameter(command, DbType.Int16, "ImportFileBatchId", importFileBatch.ImportFileBatchId);
                AddParameter(command, DbType.Int32, "ImportFileBatchStatusId", (short)importFileBatchStatus);
                command.ExecuteNonQuery();
            }
        }
    }
}
