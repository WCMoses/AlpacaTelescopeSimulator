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
    public class slewsettleTimeController : ControllerBase
    {
        private string methodName = nameof(slewsettleTimeController).Substring(0, nameof(slewsettleTimeController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<IntResponse> Get(int ClientID, int ClientTransactionID)
        {
            return new IntResponse(ClientID, ClientTransactionID, methodName, 2);
        }

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] int SlewSettleTime)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}