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
    public class sitelongitudeController : ControllerBase
    {
        private string methodName = nameof(sitelongitudeController).Substring(0, nameof(sitelongitudeController).IndexOf("Controller"));
        [HttpGet]
        public ActionResult<DoubleResponse> Get(int ClientID, int ClientTransactionID)
        {
            DoubleResponse result = new DoubleResponse(ClientID, ClientTransactionID, methodName, 100);
            return result;
        }


        
        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double SiteLongitude)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}