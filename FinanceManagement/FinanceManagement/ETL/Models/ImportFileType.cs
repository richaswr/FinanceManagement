namespace FinanceManagement.ETL.Models
{
    public class ImportFileType
    {
        public int ImportFileTypeId { get; set; }
        public string Description { get; set; }
        public string FileExtension { get; set; }
        public string ColumnDelimiter { get; set; }
        public string SourceDirectory { get; set; }
        public string FileNamePattern { get; set; }
        public string PostLoadProcedure { get; set; }
        public string StagingTable { get; set; }
        public bool IsActive { get; set; }
    }
}
