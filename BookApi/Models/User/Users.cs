using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookApi.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Int64 Mobile { get; set; }
        public int AccountStatus { get; set; }

        public Users(int userId, string name, string username, string password, string email,
            long mobile, int accountStatus)
        {
            UserId = userId;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            Mobile = mobile;
            AccountStatus = accountStatus;
        }
    }
}