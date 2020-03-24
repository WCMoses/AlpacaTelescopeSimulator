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

        [HttpPut]  
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] TelescopeAxes axis, [FromForm] double rate)
        {
            Program.TraceLogger.LogMessage(methodName + " PUT", "");
            Program.Simulator.MoveAxis(axis,rate); 

            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
        }
    }
