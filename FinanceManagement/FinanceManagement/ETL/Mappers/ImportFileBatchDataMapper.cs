namespace FinanceManagement.ETL.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class ImportFileBatchDataMapper : DataMapper<ImportFileBatch>
    {
        protected override ImportFileBatch Map(IDataRecord record)
        {            
            return new ImportFileBatch
            {
                ImportFileBatchId = Convert.ToInt32(record["ImportFileBatchId"]),
                ImportFileTypeId = Convert.ToInt32(record["ImportFileTypeId"]),
                ImportFileName = record["ImportFileName"] == DBNull.Value ? string.Empty : record["ImportFileName"].ToString()
            };
        }
    }
}
