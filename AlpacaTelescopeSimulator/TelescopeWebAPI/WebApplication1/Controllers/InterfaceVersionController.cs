using System;
using Microsoft.AspNetCore.Mvc;

namespace ASCOMCore.Controllers
{
    [Route("api/v1/telescope/{id}/[controller]")]
    [ApiController]
    public class InterfaceVersionController : ControllerBase
    {
        private string methodName = nameof(InterfaceVersionController).Substring(0, nameof(InterfaceVersionController).IndexOf("Controller"));

        [HttpGet()]
        public ActionResult<ShortResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                short interfaceVersion = Program.Simulator.InterfaceVersion;
                Program.TraceLogger.LogMessage(methodName + " Get", interfaceVersion.ToString());
                var response = new ShortResponse(ClientTransactionID, ClientID, methodName, interfaceVersion);
                return response;
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new ShortResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage= ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
