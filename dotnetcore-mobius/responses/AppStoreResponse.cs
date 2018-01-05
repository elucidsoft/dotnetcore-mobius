using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnetcore_mobius.responses
{
    public class AppStoreResponse
    {
        public AppStoreResponse(string numberOfCredits)
        {
            NumberOfCredits = numberOfCredits;
        }

        [JsonProperty(PropertyName = "num_credits")]
        public string NumberOfCredits { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool? Success { get; set; }
    }
}
