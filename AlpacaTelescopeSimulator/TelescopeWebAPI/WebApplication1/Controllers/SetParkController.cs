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
    public class setparkController : ControllerBase
    {
        private string methodName = nameof(setparkController).Substring(0, nameof(setparkController).IndexOf("Controller"));
        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID)
        {
            Program.TraceLogger.LogMessage(methodName + " Put", "");
            Program.Simulator.SetPark();

            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}