using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class GetCustomerController : Controller
    {
        [HttpGet("get")]
        public async Task<object> GetCustomer([FromBody] string some)
        {
            return null;
        }
    }
}