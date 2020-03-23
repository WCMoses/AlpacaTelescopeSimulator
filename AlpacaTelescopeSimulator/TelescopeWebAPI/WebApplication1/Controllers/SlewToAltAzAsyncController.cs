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
    public class slewtoaltazasyncController : ControllerBase
    {
        private string methodName = nameof(slewtoaltazasyncController).Substring(0, nameof(slewtoaltazasyncController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double Altitude, [FromForm] double Azimuth)
        {
            Program.TraceLogger.LogMessage(methodName + " Put", "");
            Program.Simulator.SlewToAltAzAsync(Azimuth,Altitude);

            return new MethodResponse(ClientTransactionID, ClientID, "SlewToAltAzAsync");

        }
    }
}