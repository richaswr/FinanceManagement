namespace FinanceManagement.Users.Repositories
{
    using System.Collections.ObjectModel;
    using System.Data;
    using DataAccess;
    using Mappers;
    using Models;

    public class UserRepository : DataContext, IUserRepository
    {
        public User GetUserByEmailAddress(string emailAddress)
        {
            var mapper = new UserMapper();
            var user = new User();

            SetSqlConnection();
            using(Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetUserByEmailAddress))
            {
                AddParameter(command, DbType.String, "EmailAddress", emailAddress);
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        user = mapper.MapSingle(reader);
                    }
                }
            }

            return user;
        }

        public User GetUserByUserId(int userId)
        {
            var mapper = new UserMapper();
            var user = new User();

            SetSqlConnection();
            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetUserByUserId))
            {
                AddParameter(command, DbType.Int32, "UserId", userId);
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        user = mapper.MapSingle(reader);
                    }
                }
            }

            return user;
        }

        public Collection<User> GetUsers()
        {
            var mapper = new UserMapper();
            var users = new Collection<User>();

            SetSqlConnection();

            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetUsers))
            {
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        users = mapper.MapAll(reader);
                    }
                }
            }

            return users;
        }

        public Collection<AspNetRole> GetRolesByUserId(int userId)
        {
            var mapper = new AspNetRoleMapper();
            var userRoles = new Collection<AspNetRole>();

            SetSqlConnection();
            using (Connection)
            using (var command = CreateSqlCommand(StoredProcedures.GetRolesByUserId))
            {
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        userRoles = mapper.MapAll(reader);
                    }
                }
            }

            return userRoles;
        }
    }
}
