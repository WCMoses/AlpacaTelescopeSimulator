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
    public class aperturediameterController : ControllerBase
    {
        private string methodName = nameof(aperturediameterController).Substring(0, nameof(aperturediameterController).IndexOf("Controller"));

        // GET: api/ApertureDiameter
        [HttpGet]
        public DoubleResponse Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                double AperatureDiameter = Program.Simulator.ApertureDiameter;
                Program.TraceLogger.LogMessage(methodName + " Get", AperatureDiameter.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, AperatureDiameter);
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
