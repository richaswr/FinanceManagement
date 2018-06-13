namespace FinanceManagement.Users.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class UserMapper : DataMapper<User>
    {
        private readonly AspNetUserMapper _aspNetUserMapper;

        public UserMapper()
        {
            _aspNetUserMapper = new AspNetUserMapper();
        }

        protected override User Map(IDataRecord record)
        {
            return new User
            {
                UserId = Convert.ToInt32(record["UserId"]),
                CreatedDate = DateTime.Parse(record["CreatedDate"].ToString()),
                AspNetUserId = record["AspNetUserId"] == DBNull.Value ? string.Empty : record["AspNetUserId"].ToString(),
                AspNetUser = _aspNetUserMapper.MapSingle(record)
            };
        }
    }
}
