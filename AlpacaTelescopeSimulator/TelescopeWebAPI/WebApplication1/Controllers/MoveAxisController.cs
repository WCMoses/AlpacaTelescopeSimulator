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
    public class moveaxisController : ControllerBase
    {
        private string methodName = nameof(moveaxisController).Substring(0, nameof(moveaxisController).IndexOf("Controller"));

        [HttpPut]  //TODO: implememt
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] int axis, [FromForm] double rate)
        {
            //TODO: Not fully implemented yet
            Program.TraceLogger.LogMessage(methodName + " Get", "");
            ASCOM.DeviceInterface.TelescopeAxes a = TelescopeAxes.axisPrimary;
            Program.Simulator.MoveAxis(a,rate); //<<---  implement

            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
        }
    }
