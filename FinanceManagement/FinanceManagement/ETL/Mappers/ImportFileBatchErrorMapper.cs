namespace FinanceManagement.ETL.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class ImportFileBatchErrorMapper : DataMapper<ImportFileBatchError>
    {
        private readonly ImportFileBatch _importFileBatch;

        public ImportFileBatchErrorMapper(ImportFileBatch importFileBatch)
        {
            _importFileBatch = importFileBatch;
        }

        protected override ImportFileBatchError Map(IDataRecord record)
        {
            return new ImportFileBatchError
            {
                BatchErrorStatus = record["BatchErrorStatusId"] == DBNull.Value
                    ? BatchErrorStatus.Open
                    : (BatchErrorStatus)Enum.Parse(typeof(BatchErrorStatus), record["BatchErrorStatusId"].ToString()),
                BatchRowId = record["BatchRowId"] == DBNull.Value ? default(int) : int.Parse(record["BatchRowId"].ToString()),
                DateClosed = record["DateClosed"] == DBNull.Value ? (DateTime?) null : DateTime.Parse(record["DateClosed"].ToString()),
                ErrorMessage = record["ErrorMessage"] == DBNull.Value ? string.Empty : record["ErrorMessage"].ToString(),
                ImportFileBatch = _importFileBatch,
                ImportFileBatchErrorId = int.Parse(record["ImportFileBatchErrorId"].ToString())
            };
        }
    }
}