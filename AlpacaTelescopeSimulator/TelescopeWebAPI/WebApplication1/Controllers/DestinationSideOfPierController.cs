using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASCOM.DeviceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;
using ASCOMCore.Response_Classes;

namespace ASCOMCore.Controllers
{
    [Route("telescope/{device_number}/[controller]")]
    [ApiController]
    public class destinationsideOfpierController : ControllerBase
    {
        private string methodName = nameof(destinationsideOfpierController).Substring(0, nameof(destinationsideOfpierController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<PierSideResponse> Get(int ClientID, int ClientTransactionID)
        {
 try
            {
                PierSide result = Program.Simulator.DestinationSideOfPier(1,1);
                Program.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new PierSideResponse(ClientTransactionID, ClientID,result);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                PierSideResponse response = new PierSideResponse(ClientTransactionID, ClientID, 0, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}