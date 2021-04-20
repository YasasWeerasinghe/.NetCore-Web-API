using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
   public interface IAccountInfoRepository
    {
        Task<IEnumerable<AccountInfo>> GetAccountInfos();
        Task<AccountInfo> GetAccountInfo(int custregistrationid);
        Task<AccountInfo> AddAccountInfo(AccountInfo accountInfo);
        Task<AccountInfo> UpdateAccountInfo(AccountInfo accountInfo);
        void DeleteAccountInfo(int custRegistrationId);
    }
}
