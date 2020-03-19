using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASCOM.DeviceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;
using ASCOMCore.Response_Classes;

namespace ASCOMCore.Controllers
{
    [Route("telescope/{device_number}/[controller]")]
    [ApiController]
    public class sideofpierController : ControllerBase
    {
        private string methodName = nameof(sideofpierController).Substring(0, nameof(sideofpierController).IndexOf("Controller"));
        // GET: api/SideOfPier
        [HttpGet]
        public ActionResult<PierSideResponse> Get(int ClientID, int ClientTransactionID)
        {
           try
            {
                var result = Program.Simulator.SideOfPier;
                Program.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new PierSideResponse(ClientTransactionID, ClientID,result);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new PierSideResponse(ClientTransactionID, ClientID,PierSide.pierUnknown);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }


        // PUT: api/SideOfPier/5
        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] int SideOfPier)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }


    }
}
