using System;
using System.Net;

namespace Api.Infra.CrossCutting.Exceptions
{
    public class RestException : Exception
    {
        public HttpStatusCode Code { get; }
        public object Error { get; }

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