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
    public class slewtocoordinatesasyncController : ControllerBase
    {
        private string methodName = nameof(slewtocoordinatesasyncController).Substring(0, nameof(slewtocoordinatesasyncController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double RightAscension, [FromForm] double Declination)
        {
            try
            {
                Program.TraceLogger.LogMessage(methodName, string.Format("Command: {0}, Parameters: {1}", RightAscension, Declination));
                Program.Simulator.SlewToCoordinatesAsync(RightAscension, Declination);
                Program.TraceLogger.LogMessage(methodName, string.Format("Command: {0} completed OK", methodName));
                return new MethodResponse(ClientTransactionID, ClientID, methodName);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName, string.Format("Exception: {0}", ex.ToString()));
                MethodResponse response = new MethodResponse(ClientTransactionID, ClientID, methodName);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}