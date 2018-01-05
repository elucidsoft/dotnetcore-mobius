using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnetcore_mobius.responses
{
    public class TokensResponse : TokenResponse
    {
        [JsonProperty(PropertyName = "uid")]
        public string Uid { get; set; }
    }
}
