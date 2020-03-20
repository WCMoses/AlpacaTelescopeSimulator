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
    public class canpulseguideController : ControllerBase
    {
        private string methodName = nameof(canpulseguideController).Substring(0, nameof(canpulseguideController).IndexOf("Controller"));
        // GET: api/AtHome
        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanPulseGuide = Program.Simulator.CanPulseGuide;
                Program.TraceLogger.LogMessage(methodName + " Get", CanPulseGuide.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanPulseGuide);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                BoolResponse response = new BoolResponse(ClientTransactionID, ClientID, methodName, false);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}