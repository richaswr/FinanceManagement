namespace FinanceManagement.ETL.Models
{
    using System;

    public class ImportFileType
    {
        [DataTableIgnore]
        public byte ImportFileTypeId { get; set; }

        public string Description { get; set; }

        [DataTableIgnore]
        public string FileExtension { get; set; }

        [DataTableIgnore]
        public string ColumnDelimiter { get; set; }

        public string SourceDirectory { get; set; }
        public string FileNamePattern { get; set; }

        [DataTableIgnore]
        public string PostLoadProcedure { get; set; }

        [DataTableIgnore]
        public string StagingTable { get; set; }

        [DataTableIgnore]
        public bool IsActive { get; set; }

        [DataTableIgnore]
        public DateTime? DateLastRun { get; set; }
    }
}