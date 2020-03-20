using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASCOMCore.Controllers
{
    [Route("api/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class SupportedActionsController : ControllerBase
    {
        private string methodName = nameof(SupportedActionsController).Substring(0, nameof(SupportedActionsController).IndexOf("Controller"));

        [HttpGet()]
        public ActionResult<StringListResponse> Get(int ClientID, int ClientTransactionID)
        {
            List<string> list = new List<string>();
            string concatenatedList  = null;
            try
            {

                if (list != null)
                {
                    foreach (string supportedAction in Program.Simulator.SupportedActions)
                    {
                        list.Add(supportedAction);
                    }
                     concatenatedList = string.Join(" ", list);
                }

                Program.TraceLogger.LogMessage(methodName + " Get", concatenatedList);
                return new StringListResponse(ClientTransactionID, ClientID, methodName, list);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName, string.Format("Exception calling {0}: {1}", methodName, ex.ToString()));
                StringListResponse response = new StringListResponse(ClientTransactionID, ClientID, methodName, new List<string>());
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
