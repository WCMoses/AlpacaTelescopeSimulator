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
    public class GuideRateDeclinationController : ControllerBase
    {
        private string methodName = nameof(canslewController).Substring(0, nameof(canslewController).IndexOf("Controller"));
        // GET: api/GuideRateDeclination

        [HttpGet]
        public ActionResult<DoubleResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = Program.Simulator.FocalLength;
                Program.TraceLogger.LogMessage(methodName + " Get", "");

                return new DoubleResponse(ClientTransactionID, ClientID, methodName, result);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double GuideRateDeclination)
        {
            Program.TraceLogger.LogMessage(methodName + " Get", "");
            Program.Simulator.GuideRateDeclination = GuideRateDeclination;

            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }

    }
}
