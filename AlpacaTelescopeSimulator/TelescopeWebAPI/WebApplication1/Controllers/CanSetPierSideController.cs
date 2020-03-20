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
    public class canfindpiersideController : ControllerBase
    {
        private string methodName = nameof(canfindpiersideController).Substring(0, nameof(canfindpiersideController).IndexOf("Controller"));

        // GET: api/CanSetPierSide
        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanSetPierSide = Program.Simulator.CanSetPierSide;
                Program.TraceLogger.LogMessage(methodName + " Get", CanSetPierSide.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanSetPierSide);
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
