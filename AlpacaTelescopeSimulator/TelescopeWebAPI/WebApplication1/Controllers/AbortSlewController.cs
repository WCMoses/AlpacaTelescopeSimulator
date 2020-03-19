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
    public class abortslewController : ControllerBase
    {
        private string methodName = nameof(abortslewController).Substring(0, nameof(abortslewController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}