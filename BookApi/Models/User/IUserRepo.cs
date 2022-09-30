using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    internal interface IUserRepository
    {
        List<Users> GetUsers();
        bool Login(string username, string password);
        void AddUser(Users user);
        void DeleteUser(int userId);
        void UpdateUser(Users user);
        void AdminUpdateUser(int id, int status);

    }
}
