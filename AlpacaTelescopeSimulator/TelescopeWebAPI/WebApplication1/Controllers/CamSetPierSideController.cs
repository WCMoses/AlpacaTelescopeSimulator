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
    public class cansetpiersideController : ControllerBase
    {
        private string methodName = nameof(cansetpiersideController).Substring(0, nameof(cansetpiersideController).IndexOf("Controller"));

        // GET: api/CamSetPierSide
        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                bool CanSetPier = Program.Simulator.CanSetPierSide;
                Program.TraceLogger.LogMessage(methodName + " Get", CanSetPier.ToString());
                return new BoolResponse(ClientTransactionID, ClientID, methodName, CanSetPier);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                BoolResponse response = new BoolResponse(ClientTransactionID, ClientID, methodName, false);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }


    }
}
