namespace FinanceManagement.Users.Repositories
{
    using System.Collections.ObjectModel;
    using Models;

    public interface IUserRepository
    {
        User GetUserByEmailAddress(string emailAddress);
        User GetUserByUserId(int userId);
        Collection<User> GetUsers();
        Collection<AspNetRole> GetRolesByUserId(int userId);
    }
}
