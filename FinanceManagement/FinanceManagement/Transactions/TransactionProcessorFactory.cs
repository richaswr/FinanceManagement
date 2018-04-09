namespace FinanceManagement.Transactions
{
    using System;
    using ETL.Models;
    using ETL.Repositories;
    using Processors;

    public class TransactionProcessorFactory
    {
        public static ITransactionProcessor GetTransactionProcessor(ImportFileType importFileType, IEtlRepository etlRepository)
        {
            switch (importFileType.ImportFileTypeId)
            {
                case 1: return new MonzoTransactionProcessor(importFileType, etlRepository);
                case 2: return new SantanderTransactionProcessor(importFileType, etlRepository);
                default: throw new ArgumentException();
            }
        }
    }
}
