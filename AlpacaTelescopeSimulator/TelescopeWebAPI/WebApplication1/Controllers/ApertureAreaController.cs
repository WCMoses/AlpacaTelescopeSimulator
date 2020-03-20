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
    public class apertureareaController : ControllerBase
    {
        private string methodName = nameof(apertureareaController).Substring(0, nameof(apertureareaController).IndexOf("Controller"));

        // GET: api/ApertureArea
        [HttpGet]
        public ActionResult<DoubleResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                double aperature = Program.Simulator.Altitude;
                Program.TraceLogger.LogMessage(methodName + " Get", aperature.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, aperature);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                DoubleResponse response = new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

        
   

    

       
    }
}
