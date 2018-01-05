using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnetcore_mobius.responses
{
    public class GetTransferInfoResponse
    {
        [JsonProperty(PropertyName = "uid")]
        public string Uid { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "tx_hash")]
        public string TransactionHash { get; set; }
    }
}
