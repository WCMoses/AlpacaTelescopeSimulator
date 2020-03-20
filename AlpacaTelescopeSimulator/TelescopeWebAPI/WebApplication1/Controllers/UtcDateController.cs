using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;

namespace ASCOMCore.Controllers
{
    [Route("api/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class utcdateController : ControllerBase
    {
        private string methodName =
            nameof(utcdateController).Substring(0, nameof(utcdateController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<StringResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var response = Program.Simulator.UTCDate;
                Program.TraceLogger.LogMessage(methodName + " Get", response.ToString());
                return new StringResponse(ClientTransactionID, ClientID, methodName, response.ToString());
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new StringResponse(ClientTransactionID, ClientID, methodName, Response.ToString());
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;

            }

        }

        // PUT: api/DeclinationRate/5
        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] string dateTime)
        {
            Program.TraceLogger.LogMessage(methodName + " Put", "");
            Program.Simulator.UTCDate = DateTime.Parse(dateTime);
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }

    }
}
