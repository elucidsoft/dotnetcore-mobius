using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnetcore_mobius.responses
{
    public class GetAddressBalanceResponse
    {
        [JsonProperty(PropertyName = "balance")]
        public string Balance { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "token")]
        private TokenResponse Token { get; set; }
    }
}
