using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dotnetcore_mobius.responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotnetcore_mobius.requests
{
    public class DataFeedRequestBuilder : RequestBuilder<DataFeedRequestBuilder>
    {
        public DataFeedRequestBuilder(HttpClient httpClient, Uri serverUri) 
            : base(httpClient, serverUri, "data_marketplace")
        {
        }

        public DataFeedRequestBuilder GetDataFeed(string dataFeedUid)
        {
            SetSegments("data_marketplace", "data_feed");
            UriBuilder.SetQueryParam("data_feed_uid", dataFeedUid);

            return this;
        }

        public DataFeedRequestBuilder BuyDataFeed(string dataFeedUid, string address)
        {
            SetSegments("data_marketplace", "buy");
            SetRequestType(RequestType.Post);
            UriBuilder.SetQueryParam("data_feed_uid", dataFeedUid);
            UriBuilder.SetQueryParam("address", address);

            return this;
        }

        public DataFeedRequestBuilder CreateDataPoint(string dataFeedUid, Dictionary<string, string> values)
        {
            var content = JsonConvert.SerializeObject(values);
            SetRequestType(RequestType.Post);
            SetSegments("data_marketplace", "data_feed");
            UriBuilder.SetQueryParam("data_feed_uid", dataFeedUid);
            UriBuilder.SetQueryParam("values", content);

            return this;
        }

        public async Task<DataFeedResponse> Execute()
        {
            return await Execute<DataFeedResponse>(BuildUri());
        }
    }
}
