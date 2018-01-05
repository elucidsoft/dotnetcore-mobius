using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnetcore_mobius.responses
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "issuer")]
        public string Issuer { get; set; }
    }
}
