using System;

namespace dotnetcore_mobius.requests
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(int statusCode, string s)
            : base(s)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
    }
}