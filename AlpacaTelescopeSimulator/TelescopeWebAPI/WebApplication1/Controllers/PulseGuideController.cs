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
    public class pulseguideController : ControllerBase
    {
        private string methodName = nameof(pulseguideController).Substring(0, nameof(pulseguideController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] ASCOM.DeviceInterface.GuideDirections Direction, [FromForm] int Duration)
        {
             Program.TraceLogger.LogMessage(methodName + " Put", "");
            Program.Simulator.PulseGuide(Direction,Duration);

            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}