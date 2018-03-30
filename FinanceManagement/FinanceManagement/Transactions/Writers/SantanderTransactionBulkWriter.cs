namespace FinanceManagement.Transactions.Writers
{
    using System.Collections.ObjectModel;
    using System.Data.SqlClient;
    using DataAccess;
    using ETL.Models;
    using Models;

    public class SantanderTransactionBulkWriter : BulkWriter<SantanderTransaction>
    {
        public override ImportFileBatch ImportFileBatch { get; }
        protected override Collection<SqlBulkCopyColumnMapping> GetMappings()
        {
            return new Collection<SqlBulkCopyColumnMapping>
            {
                new SqlBulkCopyColumnMapping("ImportFileBatchId", "ImportFileBatchId"),
                new SqlBulkCopyColumnMapping("BatchRowId", "BatchRowId"),
                new SqlBulkCopyColumnMapping("Id", "Id"),
                new SqlBulkCopyColumnMapping("Date", "Date"),
                new SqlBulkCopyColumnMapping("Type", "Type"),
                new SqlBulkCopyColumnMapping("MerchantOrDescription", "MerchantOrDescription"),
                new SqlBulkCopyColumnMapping("DebitOrCredit", "DebitOrCredit"),
                new SqlBulkCopyColumnMapping("Balance", "Balance")
            };
        }
    }
}
