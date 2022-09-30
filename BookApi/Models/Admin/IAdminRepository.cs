using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    internal interface IAdminRepository
    {
        List<Admins> GetAdmins();
        bool Login(string username, string password);
        void AddAdmin(Admins admin);
        void DeleteAdmin(int userId);
        void UpdateAdmin(Admins admin);
    }
}
