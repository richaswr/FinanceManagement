namespace FinanceManagement.ETL.Models
{
    using System;

    public class ImportFileBatchError
    {
        public int ImportFileBatchErrorId { get; set; }
        public ImportFileBatch ImportFileBatch { get; set; }
        public int? BatchRowId { get; set; }
        public string ErrorMessage { get; set; }
        public BatchErrorStatus BatchErrorStatus { get; set; }
        public DateTime? DateClosed { get; set; }
    }
}
