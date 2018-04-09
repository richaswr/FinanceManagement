namespace TestConsole
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Odbc;
    using System.IO;
    using System.Linq;
    using FinanceManagement.ETL.Repositories;
    using FinanceManagement.Transactions;

    public class Program
    {
        static void Main(string[] args)
        {
            var etlRepository = new EtlRepository();
            foreach (var config in etlRepository.GetActiveImportFileTypes())
            {
                Console.WriteLine("{0}:{1}, {2}", DateTimeOffset.Now, config.ImportFileTypeId, config.Description);
                var processor = TransactionProcessorFactory.GetTransactionProcessor(config, etlRepository);

                processor.Execute();
            }
            Console.WriteLine("{0}: Complete", DateTimeOffset.Now);
            Console.ReadKey();
        }        
    }
}
