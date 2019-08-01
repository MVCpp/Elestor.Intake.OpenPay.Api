using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Openpay.Entities;
using Elestor.Intake.OpenPay.Api.Handlers;
using System;
using Elestor.Intake.OpenPay.Api.Log;
using Microsoft.AspNetCore.Http;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class AddCustomerController : Controller
    {
        private readonly ILog _log;
        public AddCustomerController(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), "Cannot be null.");
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                //_log.Error(nameof(key).ToString() + "Cannot be null.");
                //throw new ArgumentNullException(nameof(key), "Cannot be null.");
            }

            Customer customerCreated = null;

            try
            {
                _log.Information("Adding Customer.");
                var openpayAPI = OpenPayHandler.GetOpenPayInstance();

                //Customer customer = new Customer();

                //customer.Name = "Net Client";
                //customer.LastName = "C#";
                //customer.Email = "net@c.com";
                //customer.Address = new Address();
                //customer.Address.Line1 = "line 1";
                //customer.Address.PostalCode = "12355";
                //customer.Address.City = "Queretaro";
                //customer.Address.CountryCode = "MX";
                //customer.Address.State = "Queretaro";

                customerCreated = openpayAPI.CustomerService.Create(customer);

            }
            catch (Exception ex)
            {
                _log.Error("Exception while adding customer." + ex.ToString());
                return NotFound();
            }

            return Ok(customerCreated);
        }
    }
}