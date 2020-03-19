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
    public class canparkController : ControllerBase
    {
        private string methodName = nameof(canparkController).Substring(0, nameof(canparkController).IndexOf("Controller"));

        // GET: api/AtHome
        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanPark = Program.Simulator.CanPark;
                Program.TraceLogger.LogMessage(methodName + " Get", CanPark.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanPark);
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