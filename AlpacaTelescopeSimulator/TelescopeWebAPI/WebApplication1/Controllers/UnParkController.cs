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
    public class unparkController : ControllerBase
    {
        private string methodName = nameof(unparkController).Substring(0, nameof(unparkController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID)
        {
            Program.Simulator.Unpark();
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}