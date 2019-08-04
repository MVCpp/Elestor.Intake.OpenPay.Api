using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elestor.Intake.OpenPay.Api.Handlers;
using Elestor.Intake.OpenPay.Api.Log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Openpay.Entities;

namespace Elestor.Intake.OpenPay.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/card")]
    public class AddCardController : Controller
    {
        private readonly ILog _log;

        public AddCardController(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log), "Cannot be null.");
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddCustomer([FromBody] Card request, [FromBody] string customer_id)
        {
            if (request == null)
            {
                _log.Error(nameof(request).ToString() + "Cannot be null.");
                throw new ArgumentNullException(nameof(request), "Cannot be null.");
            }

            Customer customerCreated = null;

            try
            {
                _log.Information("Adding Customer.");

                var openpayAPI = OpenPayHandler.GetOpenPayInstance();

                openpayAPI.CardService.Create(customer_id, request);
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