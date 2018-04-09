namespace FinanceManagement.Transactions.Writers
{
    using System.Collections.ObjectModel;
    using System.Data.SqlClient;
    using ETL.Models;
    using Models;

    public class SantanderTransactionBulkWriter : BulkWriter<SantanderTransaction>
    {
        public SantanderTransactionBulkWriter(ImportFileBatch importFileBatch) : base(importFileBatch)
        {
        }

        protected override Collection<SqlBulkCopyColumnMapping> GetMappings()
        {
            return new Collection<SqlBulkCopyColumnMapping>
            {
                new SqlBulkCopyColumnMapping("ImportFileBatchId", "ImportFileBatchId"),
                new SqlBulkCopyColumnMapping("BatchRowId", "BatchRowId"),
                new SqlBulkCopyColumnMapping("Date", "Date"),
                new SqlBulkCopyColumnMapping("Type", "Type"),
                new SqlBulkCopyColumnMapping("MerchantOrDescription", "MerchantOrDescription"),
                new SqlBulkCopyColumnMapping("DebitOrCredit", "DebitOrCredit"),
                new SqlBulkCopyColumnMapping("Balance", "Balance")
            };
        }
    }
}
