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
    public class rightsscensionController : ControllerBase
    {
        private string methodName = nameof(rightsscensionController).Substring(0, nameof(rightsscensionController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<DoubleResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                double altitude = Program.Simulator.RightAscension;
                Program.TraceLogger.LogMessage(methodName + " Get", altitude.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, altitude);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                DoubleResponse response = new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            } 
        }

    }
}