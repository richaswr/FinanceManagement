namespace FinanceManagement.ETL.Models
{
    public class ImportFileBatch
    {
        public int ImportFileBatchId { get; set; }
        public int ImportFileTypeId { get; set; }
        public string ImportFileName { get; set; }
        public ImportFileType ImportFileType { get; set; }
    }
}
