using System;
using System.Net;

namespace Api.Infra.CrossCutting.Exceptions
{
    /// <summary>
    /// Rest Exception
    /// </summary>
    public class RestException : Exception
    {
        /// <summary>
        /// Code status of http request
        /// </summary>
        public HttpStatusCode Code { get; }

        /// <summary>
        /// Error object
        /// </summary>
        public object Error { get; }

        /// <summary>
        /// Method to get rest exception
        /// </summary>
        /// <param name="code"></param>
        /// <param name="statusText"></param>
        /// <param name="error"></param>
        public RestException(HttpStatusCode code, string statusText, object error = null)
        {
            Code = code;
            if (error == null)
            {
                Error = new
                {
                    StatusText = statusText
                };
            }
            else
            {
                Error = error;
            }
        }
    }
}