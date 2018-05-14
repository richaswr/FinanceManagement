namespace FinanceManagement.ETL.Repositories
{
    using System;
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
            var mapper = new ImportFileBatchDataMapper(importFileType);
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

            return importFileBatch;
        }

        public ImportFileType CreateImportFileType(ImportFileType importFileType)
        {
            var newImportFileType = new ImportFileType();
            var mapper = new ImportFileTypeDataMapper();

            SetSqlConnection();
            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.CreateImportFileType))
            {
                AddParameter(command, DbType.String, "Description", importFileType.Description);
                AddParameter(command, DbType.String, "FileExtension", importFileType.FileExtension);
                AddParameter(command, DbType.String, "ColumnDelimiter", importFileType.ColumnDelimiter);
                AddParameter(command, DbType.String, "SourceDirectory", importFileType.SourceDirectory);
                AddParameter(command, DbType.String, "FileNamePattern", importFileType.FileNamePattern);
                AddParameter(command, DbType.String, "PostLoadProcedure", importFileType.PostLoadProcedure);
                AddParameter(command, DbType.String, "StagingTable", importFileType.StagingTable);
                AddParameter(command, DbType.Boolean, "IsActive", importFileType.IsActive);
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        newImportFileType = mapper.MapSingle(reader);
                    }
                }
            }

            return newImportFileType;
        }

        public Collection<ImportFileBatch> GetImportFileBatchesByTypeAndDate(ImportFileType importFileType, DateTime fromDate)
        {
            var importFileBatches = new Collection<ImportFileBatch>();
            var mapper = new ImportFileBatchDataMapper(importFileType);

            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetImportFileBatchesByTypeAndDate))
            {
                AddParameter(command, DbType.Byte, "ImportFileTypeId", importFileType.ImportFileTypeId);
                AddParameter(command, DbType.DateTime, "DateFrom", fromDate);
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        importFileBatches = mapper.MapAll(reader);
                    }
                }
            }

            return importFileBatches;
        }

        public Collection<ImportFileBatchError> GetImportFileBatchErrors(ImportFileBatch importFileBatch)
        {
            var importFileBatchErrors = new Collection<ImportFileBatchError>();
            var mapper = new ImportFileBatchErrorMapper(importFileBatch);

            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetImportFileBatchErrors))
            {
                AddParameter(command, DbType.Int32, "ImportFileBatchId", importFileBatch.ImportFileBatchId);
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        importFileBatchErrors = mapper.MapAll(reader);
                    }
                }
            }

            return importFileBatchErrors;
        }

        public Collection<ImportFileType> GetImportFileTypes()
        {
            var mapper = new ImportFileTypeDataMapper();

            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetImportFileTypes))
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

        public void UpdateImportFileType(ImportFileType importFileType)
        {
            SetSqlConnection();
            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.UpdateImportFileType))
            {
                AddParameter(command, DbType.Int32, "ImportFileTypeId", importFileType.ImportFileTypeId);
                AddParameter(command, DbType.String, "Description", importFileType.Description);
                AddParameter(command, DbType.String, "FileExtension", importFileType.FileExtension);
                AddParameter(command, DbType.String, "ColumnDelimiter", importFileType.ColumnDelimiter);
                AddParameter(command, DbType.String, "SourceDirectory", importFileType.SourceDirectory);
                AddParameter(command, DbType.String, "FileNamePattern", importFileType.FileNamePattern);
                AddParameter(command, DbType.String, "PostLoadProcedure", importFileType.PostLoadProcedure);
                AddParameter(command, DbType.String, "StagingTable", importFileType.StagingTable);
                AddParameter(command, DbType.Boolean, "IsActive", importFileType.IsActive);

                Connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}