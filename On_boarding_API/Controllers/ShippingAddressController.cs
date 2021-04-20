using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using On_boarding_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingAddressController : ControllerBase
    {
        private readonly IAccountInfoRepository accountRepository;
        private readonly IShippingAddressRepository shippingAddressRepository;

        public ShippingAddressController(IShippingAddressRepository shippingAddressRepository)
        {
            this.shippingAddressRepository = shippingAddressRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetShippingAddresses()
        {
            try
            {
                return Ok(await shippingAddressRepository.GetShippingAddresses());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retreving data from the database \n " + e);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShippingAddress>> GetShippingAdress(int id)
        {
            try
            {
                var result = await shippingAddressRepository.GetShippingAddress(id);

                if (result == null)
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
        public async Task<ActionResult<AccountInfo>> CreateShippingAddress(ShippingAddress shippingAddress)
        {
            try
            {
                if (shippingAddress == null)
                {
                    return BadRequest();
                }
                // create a object of account info
                AccountInfoController accountInfoObj = new AccountInfoController(accountRepository);
                //get the account info custRegistrationId and assign that value to the shippingAddress foreing key custRegistrationId
                shippingAddress.CustRegistrationId = accountInfoObj.getCustRegId();
                var createShippingAdress = await shippingAddressRepository.AddShippingAddress(shippingAddress);
                return CreatedAtAction(nameof(GetShippingAddresses), new { id = createShippingAdress.ShippingId });
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retreving data from the database \n " + e);
            }
        }


    }
}
