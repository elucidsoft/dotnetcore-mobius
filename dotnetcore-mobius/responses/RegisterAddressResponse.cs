using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnetcore_mobius.responses
{
    public class RegisterAddressResponse
    {
        [JsonProperty(PropertyName = "uid")]
        public string Uid { get; set; }
    }
}
