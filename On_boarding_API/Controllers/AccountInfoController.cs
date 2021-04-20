using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using On_boarding_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Controllers
{
    // remove exeption 'e'. It' only for development 

    [Route("api/[controller]")]
    [ApiController]
    public class AccountInfoController : ControllerBase
    {
        public static int getCustID;
        private readonly IAccountInfoRepository accountRepository;
        public AccountInfoController(IAccountInfoRepository accountInfoRepository)
        {
            this.accountRepository = accountInfoRepository;
        }      
       
        [HttpGet]
        public async Task<ActionResult> GetAccountInfo()
        {
            try
            {
                return Ok(await accountRepository.GetAccountInfos());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retreving data from the database \n " + e);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AccountInfo>> GetAccountInfo(int id)
        {
            try
            {
                var result = await accountRepository.GetAccountInfo(id);

                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception e)
            {              
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retreving data from the database \n " + e);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AccountInfo>> CreateAccountInfo(AccountInfo accountInfo)
        {           
            try
            {
                if (accountInfo == null)
                {
                    return BadRequest();
                }

                var createAccountInfo = await accountRepository.AddAccountInfo(accountInfo);
                // capture the custRegistrationId 
                getCustID = accountInfo.CustRegistrationId;
                return CreatedAtAction(nameof(GetAccountInfo), new { id = createAccountInfo.CustRegistrationId }, createAccountInfo);
                
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retreving data from the database \n " + e);
            }
        }

        // get method used to store account info custRegistrationId accross with biling and shipping 
        public int getCustRegId()
        {
            return getCustID;
        }

    }
}
