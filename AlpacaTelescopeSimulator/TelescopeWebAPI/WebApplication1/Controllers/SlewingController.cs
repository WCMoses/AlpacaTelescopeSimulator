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
    public class slewingController : ControllerBase
    {
        private string methodName = nameof(slewingController).Substring(0, nameof(slewingController).IndexOf("Controller"));
        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID)
        {
            return new BoolResponse(ClientID, ClientTransactionID, methodName, true);
        }
    }
}