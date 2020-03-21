using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;

namespace ASCOMCore.Controllers
{
    using ASCOMCore;
    [Route("api/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class SiderealTimeController : ControllerBase
    {
        private string methodName = nameof(SiderealTimeController).Substring(0, nameof(SiderealTimeController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<DoubleResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                Program.TraceLogger.LogMessage(methodName + " Get", "");
                var result = Program.Simulator.SiderealTime;
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
    }
}