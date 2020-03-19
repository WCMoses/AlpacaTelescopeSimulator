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
    public class synctotargetController : ControllerBase
    {
        private string methodName = nameof(synctotargetController).Substring(0, nameof(synctotargetController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID)
        {
            Program.TraceLogger.LogMessage(methodName + " Put", "");
            Program.Simulator.SyncToTarget();
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}