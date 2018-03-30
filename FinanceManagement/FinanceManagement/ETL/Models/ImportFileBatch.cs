namespace FinanceManagement.ETL.Models
{
    public class ImportFileBatch
    {
        public int ImportFileBatchId { get; set; }
        public int ImportFileId { get; set; }
        public string ImportFileName { get; set; }
        public ImportFile ImportFile { get; set; }
    }
}
