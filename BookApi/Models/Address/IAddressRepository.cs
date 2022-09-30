using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    internal interface IAddressRepository
    {
        List<Addresses> GetAllAddresses();
        List<Addresses> GetAddressByUser(int userId);
        void AddAddress(Addresses address);
        void DeleteAddress(int AddressId);
        void UpdateAddress(Addresses address);

    }
}
