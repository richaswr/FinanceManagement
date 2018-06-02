namespace FinanceManagement.ETL.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class ImportFileBatchDataMapper : DataMapper<ImportFileBatch>
    {
        private readonly ImportFileType _importFileType;

        public ImportFileBatchDataMapper() { }
        public ImportFileBatchDataMapper(ImportFileType importFileType)
        {
            _importFileType = importFileType;
        }

        protected override ImportFileBatch Map(IDataRecord record)
        {
            var importFileBatchStatus = record["ImportFileBatchStatusId"] == DBNull.Value
                ? ImportFileBatchStatus.Pending
                : (ImportFileBatchStatus) Enum.Parse(typeof(ImportFileBatchStatus),
                    record["ImportFileBatchStatusId"].ToString());

            var importFileBatch = new ImportFileBatch
            {
                ImportFileBatchId = Convert.ToInt32(record["ImportFileBatchId"]),
                ImportFileTypeId = Convert.ToInt32(record["ImportFileTypeId"]),
                DateCreated = Convert.ToDateTime(record["DateCreated"].ToString()),
                ImportFileBatchStatus = importFileBatchStatus,
                ImportFileName = record["ImportFileName"] == DBNull.Value ? string.Empty : record["ImportFileName"].ToString(),
                RecordCount = record["RecordCount"] == DBNull.Value ? 0 : Convert.ToInt32(record["RecordCount"]),
                ImportFileBatchErrorCount = Convert.ToInt32(record["NoOfImportFileBatchErrors"])
            };

            if (_importFileType != null)
            {
                importFileBatch.ImportFileType = _importFileType;
            }

            return importFileBatch;
        }
    }
}
