namespace FinanceManagement.ETL.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class ImportFileTypeDataMapper : DataMapper<ImportFileType>
    {
        protected override ImportFileType Map(IDataRecord record)
        {
            return new ImportFileType
            {
                ImportFileTypeId = Convert.ToInt32(record["ImportFileTypeId"]),
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
