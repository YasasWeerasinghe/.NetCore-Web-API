using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
    public class AccountInfoRepository : IAccountInfoRepository
    {
        private readonly AppDBContext appDBContext;

        public AccountInfoRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        //Post method data saving
        public async Task<AccountInfo> AddAccountInfo(AccountInfo accountInfo)
        {
            var result = await appDBContext.AccountInfo.AddAsync(accountInfo);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }
        // currently not in use
        public async void DeleteAccountInfo(int custRegistrationId)
        {
            var result = await appDBContext.AccountInfo
                .FirstOrDefaultAsync(e => e.CustRegistrationId == custRegistrationId);
            if (result != null)
            {
                appDBContext.AccountInfo.Remove(result);
                await appDBContext.SaveChangesAsync();
            }
        }
        //Get with id method
        public async Task<AccountInfo> GetAccountInfo(int custRegistrationId)
        {
            return await appDBContext.AccountInfo
                .FirstOrDefaultAsync(e => e.CustRegistrationId == custRegistrationId);
        }
        //Get method as a list
        public async Task<IEnumerable<AccountInfo>> GetAccountInfos()
        {
            return await appDBContext.AccountInfo.ToListAsync();
        }
        // currently not in use
        public async Task<AccountInfo> UpdateAccountInfo(AccountInfo accountInfo)
        {
            var result = await appDBContext.AccountInfo
                .FirstOrDefaultAsync(e => e.CustRegistrationId == accountInfo.CustRegistrationId);

            if (result != null)
            {
                result.ContactPerson = accountInfo.ContactPerson;
                // ...

                await appDBContext.SaveChangesAsync();
                return result;

            }

            return null;
        }
    }
}
