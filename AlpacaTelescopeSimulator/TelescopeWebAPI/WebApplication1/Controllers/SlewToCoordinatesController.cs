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
    public class slewtocoordinatesController : ControllerBase
    {
        private string methodName = nameof(slewtocoordinatesController).Substring(0, nameof(slewtocoordinatesController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double RightAscension, [FromForm] double Declination)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}