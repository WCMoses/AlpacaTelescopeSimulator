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
    public class canslewaltazController : ControllerBase
    {
        private string methodName = nameof(canslewaltazController).Substring(0, nameof(canslewaltazController).IndexOf("Controller"));

        // GET: api/CanSlewAltAz
        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanSetAltAz = Program.Simulator.CanSlewAltAz;
                Program.TraceLogger.LogMessage(methodName + " Get", CanSetAltAz.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanSetAltAz);
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
