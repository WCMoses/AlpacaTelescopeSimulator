using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;

namespace ASCOMCore.Controllers
{
   [Route("apis/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class AlignmentModeController : ControllerBase
    {
        private string methodName = nameof(AlignmentModeController).Substring(0, nameof(AlignmentModeController).IndexOf("Controller"));

        
        [HttpGet]
        public ActionResult<AlignmentModeResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                var result = Program.Simulator.AlignmentMode;
                Program.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new AlignmentModeResponse(ClientTransactionID, ClientID, methodName, result);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new AlignmentModeResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}