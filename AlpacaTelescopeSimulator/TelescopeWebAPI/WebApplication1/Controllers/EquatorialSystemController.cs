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
    public class equatorialsystemController : ControllerBase
    {
        private string methodName = nameof(equatorialsystemController).Substring(0, nameof(equatorialsystemController).IndexOf("Controller"));
        // GET: api/EquatorialSystem
        [HttpGet]
        public ActionResult<IntResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                Program.TraceLogger.LogMessage(methodName + " Get", "");
                var result = Program.Simulator.EquatorialSystem;
                return new IntResponse(ClientTransactionID, ClientID, methodName,(int)result);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new IntResponse(ClientTransactionID, ClientID, methodName,5);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }

        }


    }
}
