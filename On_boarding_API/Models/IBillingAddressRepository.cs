using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
   public interface IBillingAddressRepository
    {
        Task<IEnumerable<BillingAddress>> GetBillingAddresses();
        Task<BillingAddress> GetBillingAdress(int billingId);
        Task<BillingAddress> AddBillingAddress(BillingAddress billingAddress);
        Task<BillingAddress> UpdateBillingAddress(BillingAddress billingAddress);
        void DeleteBillingAddress(int billingId);
    }
}
