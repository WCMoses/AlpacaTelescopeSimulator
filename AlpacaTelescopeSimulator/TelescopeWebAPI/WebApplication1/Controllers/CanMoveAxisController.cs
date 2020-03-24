using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASCOM.DeviceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;

namespace ASCOMCore.Controllers
{
    [Route("api/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class canmoveaxisController : ControllerBase
    {
        private string methodName = nameof(canmoveaxisController).Substring(0, nameof(canmoveaxisController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID, TelescopeAxes Axis)
        {
            try
            {
                bool result = Program.Simulator.CanMoveAxis(Axis);
                Program.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, result);
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