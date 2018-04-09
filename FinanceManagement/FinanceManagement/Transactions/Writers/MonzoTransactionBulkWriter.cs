namespace FinanceManagement.Transactions.Writers
{
    using System.Collections.ObjectModel;
    using System.Data.SqlClient;
    using ETL.Models;
    using Models;

    public class MonzoTransactionBulkWriter : BulkWriter<MonzoTransaction>
    {
        public MonzoTransactionBulkWriter(ImportFileBatch importFileBatch) : base(importFileBatch)
        {
        }

        protected override Collection<SqlBulkCopyColumnMapping> GetMappings()
        {
            return new Collection<SqlBulkCopyColumnMapping>
            {
                new SqlBulkCopyColumnMapping("ImportFileBatchId", "ImportFileBatchId"),
                new SqlBulkCopyColumnMapping("BatchRowId", "BatchRowId"),
                new SqlBulkCopyColumnMapping("Id", "Id"),
                new SqlBulkCopyColumnMapping("Created", "Created"),
                new SqlBulkCopyColumnMapping("Amount", "Amount"),
                new SqlBulkCopyColumnMapping("Currency", "Currency"),
                new SqlBulkCopyColumnMapping("LocalAmount", "LocalAmount"),
                new SqlBulkCopyColumnMapping("LocalCurrency", "LocalCurrency"),
                new SqlBulkCopyColumnMapping("Category", "Category"),
                new SqlBulkCopyColumnMapping("Emoji", "Emoji"),
                new SqlBulkCopyColumnMapping("Description", "Description"),
                new SqlBulkCopyColumnMapping("Address", "Address"),
                new SqlBulkCopyColumnMapping("Notes", "Notes"),
                new SqlBulkCopyColumnMapping("Receipt", "Receipt")
            };
        }
    }
}
