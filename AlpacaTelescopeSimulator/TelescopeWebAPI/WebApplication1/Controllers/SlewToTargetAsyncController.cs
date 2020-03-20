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
    public class slewtotargetasyncController : ControllerBase
    {
        private string methodName = nameof(slewtotargetasyncController).Substring(0, nameof(slewtotargetasyncController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double TargetRightAscension, [FromForm] double TargetDeclination)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}