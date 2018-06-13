namespace FinanceManagement.Users.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class AspNetUserMapper : DataMapper<AspNetUser>
    {
        protected override AspNetUser Map(IDataRecord record)
        {
            return new AspNetUser
            {
                Id = record["Id"].ToString(),
                AccessFailedCount = Convert.ToInt32(record["AccessFailedCount"]),
                ConcurrencyStamp = record["ConcurrencyStamp"] == DBNull.Value ? string.Empty : record["ConcurrencyStamp"].ToString(),
                Email = record["Email"] == DBNull.Value ? string.Empty : record["Email"].ToString(),
                EmailConfirmed = bool.Parse(record["EmailConfirmed"].ToString()),
                LockoutEnabled = bool.Parse(record["LockoutEnabled"].ToString()),
                LockoutEnd = record["LockoutEnd"] == DBNull.Value ? (DateTimeOffset?) null : DateTimeOffset.Parse(record["LockoutEnd"].ToString()),
                NormalizedEmail = record["Email"] == DBNull.Value ? string.Empty : record["NormalizedEmail"].ToString(),
                NormalizedUserName = record["Email"] == DBNull.Value ? string.Empty : record["NormalizedUserName"].ToString(),
                PasswordHash = record["Email"] == DBNull.Value ? string.Empty : record["PasswordHash"].ToString(),
                PhoneNumber = record["Email"] == DBNull.Value ? string.Empty : record["PhoneNumber"].ToString(),
                SecurityStamp = record["Email"] == DBNull.Value ? string.Empty : record["SecurityStamp"].ToString(),
                PhoneNumberConfirmed = bool.Parse(record["PhoneNumberConfirmed"].ToString()),
                TwoFactorEnabled = bool.Parse(record["TwoFactorEnabled"].ToString()),
                UserName = record["Email"] == DBNull.Value ? string.Empty : record["UserName"].ToString(),
            };
        }
    }
}
