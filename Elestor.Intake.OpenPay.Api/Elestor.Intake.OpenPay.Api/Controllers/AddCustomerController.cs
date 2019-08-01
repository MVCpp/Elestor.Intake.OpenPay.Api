using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class AddCustomerController : Controller
    {

        [HttpGet("add")]
        public async Task<object> AddCustomer(string key)
        {
            return null;
        }
    }
}