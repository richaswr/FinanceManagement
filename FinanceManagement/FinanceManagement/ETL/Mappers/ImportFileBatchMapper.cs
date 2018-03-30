namespace FinanceManagement.ETL.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class ImportFileBatchMapper : Mapper<ImportFileBatch>
    {
        protected override ImportFileBatch Map(IDataRecord record)
        {
            return new ImportFileBatch
            {
                ImportFileBatchId = Convert.ToInt32(record["ImportFileBatchId"]),
                ImportFileId = Convert.ToInt32(record["ImportFileId"]),
                ImportFileName = record["ImportFileName"] == DBNull.Value ? string.Empty : record["ImportFileName"].ToString()
            };
        }
    }
}
