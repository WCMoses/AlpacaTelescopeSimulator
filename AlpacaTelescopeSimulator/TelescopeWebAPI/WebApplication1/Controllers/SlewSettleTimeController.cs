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
    public class slewsettleTimeController : ControllerBase
    {
        private string methodName = nameof(slewsettleTimeController).Substring(0, nameof(slewsettleTimeController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<IntResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = Program.Simulator.SlewSettleTime;
                Program.TraceLogger.LogMessage(methodName + " Get", "");

                return new IntResponse(ClientTransactionID, ClientID, methodName, result);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new IntResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] short SlewSettleTime)
        {
            Program.TraceLogger.LogMessage(methodName + " Put", "");
            Program.Simulator.SlewSettleTime = SlewSettleTime;

            return new MethodResponse(ClientTransactionID, ClientID, SlewSettleTime.ToString());

        }
    }
}