using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnetcore_mobius.responses
{
    public class CreateTransferResponse
    {
        [JsonProperty(PropertyName = "token_address_transfer_uid")]
        public string TokenAddressTransferUid { get; set; }
    }
}
