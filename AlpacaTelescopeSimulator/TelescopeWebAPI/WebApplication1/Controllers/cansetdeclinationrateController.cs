using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;


namespace ASCOMCore.Controllers
{
    [Route("telescope/{device_number}/[controller]")]
    [ApiController]
    public class cansetdeclinationrateController : ControllerBase
    {
        private string methodName = nameof(cansetdeclinationrateController).Substring(0, nameof(cansetdeclinationrateController).IndexOf("Controller"));

        // GET: api/cansetdeclinationrate
        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanSetDecRate = Program.Simulator.CanSetDeclinationRate;
                Program.TraceLogger.LogMessage(methodName + " Get", CanSetDecRate.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanSetDecRate);
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
