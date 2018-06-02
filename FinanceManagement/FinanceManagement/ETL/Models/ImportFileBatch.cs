namespace FinanceManagement.ETL.Models
{
    using System;

    public class ImportFileBatch
    {
        public int ImportFileBatchId { get; set; }
        public int ImportFileTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public ImportFileBatchStatus ImportFileBatchStatus { get; set; }
        public string ImportFileName { get; set; }
        public int RecordCount { get; set; }
        public ImportFileType ImportFileType { get; set; }
        public int ImportFileBatchErrorCount { get; set; }
    }
}