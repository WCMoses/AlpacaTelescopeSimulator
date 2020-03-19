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
    public class synctoaltazController : ControllerBase
    {
        private string methodName = nameof(synctoaltazController).Substring(0, nameof(synctoaltazController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double Altitude, [FromForm] double Azimuth)
        {
            Program.TraceLogger.LogMessage(methodName + " Put", "");
            Program.Simulator.SyncToAltAz(Azimuth, Altitude);
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}