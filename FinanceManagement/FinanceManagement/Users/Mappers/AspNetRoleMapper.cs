namespace FinanceManagement.Users.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class AspNetRoleMapper : DataMapper<AspNetRole>
    {
        protected override AspNetRole Map(IDataRecord record)
        {
            return new AspNetRole
            {
                Id = record["Id"] == DBNull.Value ? string.Empty : record["Id"].ToString(),
                ConcurrencyStamp = record["ConcurrencyStamp"] == DBNull.Value ? string.Empty : record["ConcurrencyStamp"].ToString(),
                Name = record["Name"] == DBNull.Value ? string.Empty : record["Name"].ToString(),
                NormalizedName = record["NormalizedName"] == DBNull.Value ? string.Empty : record["NormalizedName"].ToString()
            };
        }
    }
}
