using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
   public interface IShippingAddressRepository
    {
        Task<IEnumerable<ShippingAddress>> GetShippingAddresses();
        Task<ShippingAddress> GetShippingAddress(int shippingId);
        Task<ShippingAddress> AddShippingAddress(ShippingAddress shippingAddress);
        Task<ShippingAddress> UpdateShippingAddress(ShippingAddress shippingAddress);
        void DeleteShippingAddress(int shippingId);
    }
}
