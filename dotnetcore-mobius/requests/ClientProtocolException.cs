using System;

namespace dotnetcore_mobius.requests
{
    public class ClientProtocolException : Exception
    {
        public ClientProtocolException(string message)
            : base(message)
        {
        }
    }
}