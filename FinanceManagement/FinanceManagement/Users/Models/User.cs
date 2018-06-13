namespace FinanceManagement.Users.Models
{
    using System;

    public class User
    {
        public int UserId { get; set; }
        public string AspNetUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public AspNetUser AspNetUser { get; set; }
    }
}
