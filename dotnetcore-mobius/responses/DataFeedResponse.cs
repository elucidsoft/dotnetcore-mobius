using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace dotnetcore_mobius.responses
{
    public class DataFeedResponse
    {
        [JsonProperty(PropertyName = "uid")]
        public string Uid { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "feed_descriptor")]
        public DataFeedResponseDescriptor[] Descriptor { get; set; }

        [JsonProperty(PropertyName = "last_updated")]
        public DateTime LastUpdated { get; set; }

        public class DataFeedResponseDescriptor
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "type")]
            public string Type { get; set; }
        }
    }

}
