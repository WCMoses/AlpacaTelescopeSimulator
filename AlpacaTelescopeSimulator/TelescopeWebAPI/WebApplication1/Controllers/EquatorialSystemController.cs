using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;
namespace ASCOMCore.Controllers  //TODO: implement
{
    [Route("api/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class equatorialsystemController : ControllerBase
    {
        private string methodName = nameof(canslewController).Substring(0, nameof(canslewController).IndexOf("Controller"));
        // GET: api/EquatorialSystem
        [HttpGet]
        public ActionResult<IntResponse> Get(int ClientID, int ClientTransactionID)
        {
            return new IntResponse(ClientID, ClientTransactionID, methodName, 2);
        }


    }
}
