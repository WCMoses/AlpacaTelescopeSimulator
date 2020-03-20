﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace ASCOMCore.Controllers
{
    [Route("api/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private string methodName = nameof(DescriptionController).Substring(0, nameof(DescriptionController).IndexOf("Controller"));

        [HttpGet()]
        public ActionResult<StringResponse> Get(int ClientID, int ClientTransactionID)
        {
            try
            {
                string description = Program.Simulator.Description;
                Program.TraceLogger.LogMessage(methodName + " Get", description);
                return new StringResponse(ClientTransactionID, ClientID, methodName, description);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                StringResponse response = new StringResponse(ClientTransactionID, ClientID, methodName, "");
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}
