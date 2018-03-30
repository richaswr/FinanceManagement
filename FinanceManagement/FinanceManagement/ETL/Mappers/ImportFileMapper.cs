namespace FinanceManagement.ETL.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class ImportFileMapper : Mapper<ImportFile>
    {
        protected override ImportFile Map(IDataRecord record)
        {
            return new ImportFile
            {
                ImportFileId = Convert.ToInt32(record["ImportFileId"]),
                ColumnDelimiter = record["ColumnDelimiter"] == DBNull.Value ? string.Empty : record["ColumnDelimiter"].ToString(),
                Description = record["Description"] == DBNull.Value ? string.Empty : record["Description"].ToString(),
                FileExtension = record["FileExtension"] == DBNull.Value ? string.Empty : record["FileExtension"].ToString(),
                IsActive = Convert.ToBoolean(record["IsActive"]),
                PostLoadProcedure = record["PostLoadProcedure"] == DBNull.Value ? string.Empty : record["PostLoadProcedure"].ToString(),
                SourceDirectory = record["SourceDirectory"] == DBNull.Value ? string.Empty : record["SourceDirectory"].ToString(),
                FileNamePattern = record["FileNamePattern"] == DBNull.Value ? "*.*" : record["FileNamePattern"].ToString(),
                StagingTable = record["StagingTable"] == DBNull.Value ? string.Empty : record["StagingTable"].ToString()
            };
        }
    }
}
