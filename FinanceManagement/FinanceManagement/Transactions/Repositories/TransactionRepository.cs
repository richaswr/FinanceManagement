namespace FinanceManagement.Transactions.Repositories
{
    using System.Data;
    using DataAccess;
    using Mappers;

    public class TransactionRepository : DataContext, ITransactionRepository
    {
        public TransactionSearchResult GetFinanceTransactions(TransactionSearchCriteria transactionSearchCriteria)
        {
            var mapper = new FinanceTransactionMapper();
            var result = new TransactionSearchResult();

            SetSqlConnection();
            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetFinanceTransactions))
            {
                AddParameter(command, DbType.Boolean, "SortByTransactionIdAscending", transactionSearchCriteria.SortByTransactionIdAscending);
                AddParameter(command, DbType.Int32, "PageSize", transactionSearchCriteria.PageSize);
                AddParameter(command, DbType.Int32, "PageRank", transactionSearchCriteria.PageRank);

                using (var reader = command.ExecuteReader())
                {
                    result.FinanceTransactions = mapper.MapAll(reader);
                    if (!reader.NextResult()) return result;
                    while (reader.Read())
                    {
                        result.TotalNumberOfRecords = int.Parse(reader["TotalNumberOfTransactions"].ToString());
                    }
                }
            }

            return result;
        }
    }
}