using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
    public class ShippingAddressRepository : IShippingAddressRepository
    {
        private readonly AppDBContext appDBContext;

        public ShippingAddressRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        //Post method data saving
        public async Task<ShippingAddress> AddShippingAddress(ShippingAddress shippingAddress)
        {
            var result = await appDBContext.ShippingAddress.AddAsync(shippingAddress);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public void DeleteShippingAddress(int shippingId)
        {
            throw new NotImplementedException();
        }
        //Get with id method
        public async Task<ShippingAddress> GetShippingAddress(int shippingId)
        {
          return await appDBContext.ShippingAddress.FirstOrDefaultAsync(e =>e.ShippingId == shippingId);
        }
        //Get method as a list
        public async Task<IEnumerable<ShippingAddress>> GetShippingAddresses()
        {
            return await appDBContext.ShippingAddress.ToListAsync();
        }

        public Task<ShippingAddress> UpdateShippingAddress(ShippingAddress shippingAddress)
        {
            throw new NotImplementedException();
        }
    }
}
