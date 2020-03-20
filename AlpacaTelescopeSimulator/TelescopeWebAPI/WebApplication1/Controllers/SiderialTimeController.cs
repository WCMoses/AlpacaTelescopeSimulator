using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;

namespace ASCOMCore.Controllers
{
    using ASCOMCore;
[Route("api/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class siderialtimeController : ControllerBase
    {
        private string methodName = nameof(siderialtimeController).Substring(0, nameof(siderialtimeController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<DoubleResponse> Get(int ClientID, int ClientTransactionID)
        {
            return new DoubleResponse(ClientID, ClientTransactionID, methodName, 2);
        }
    }
}