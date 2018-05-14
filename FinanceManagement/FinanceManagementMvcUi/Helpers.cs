namespace FinanceManagementMvcUi
{
    using FinanceManagement.ETL.Models;
    using Microsoft.AspNetCore.Http;

    public static class Helpers
    {
        public static ImportFileType ConvertIFormCollectionToImportFileType(IFormCollection formCollection)
        {
            var isActiveString = formCollection["IsActive"].ToString().Split(new[] { ',' });
            var importFileTypeId = formCollection["ImportFileTypeId"];

            var importFileType = new ImportFileType
            {
                Description = formCollection["Description"].ToString(),
                ColumnDelimiter = formCollection["ColumnDelimiter"].ToString(),
                FileNamePattern = formCollection["FileNamePattern"].ToString(),
                FileExtension = formCollection["FileExtension"].ToString(),
                SourceDirectory = formCollection["SourceDirectory"].ToString(),
                PostLoadProcedure = formCollection["PostLoadProcedure"].ToString(),
                StagingTable = formCollection["StagingTable"].ToString(),
                IsActive = isActiveString.Length > 1
            };

            if (!string.IsNullOrEmpty(importFileTypeId))
            {
                importFileType.ImportFileTypeId = byte.Parse(importFileTypeId);
            }

            return importFileType;
        }
    }
}
