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
    public class slewtotargetController : ControllerBase
    {
        private string methodName = nameof(slewtotargetController).Substring(0, nameof(slewtotargetController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID)
        {
            Program.TraceLogger.LogMessage(methodName + " Put", "");
            Program.Simulator.SlewToTarget();
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}