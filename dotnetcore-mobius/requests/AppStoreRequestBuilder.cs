using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dotnetcore_mobius.responses;

namespace dotnetcore_mobius.requests
{
    public class AppStoreRequestBuilder : RequestBuilder<AppStoreRequestBuilder>
    {
        public AppStoreRequestBuilder(HttpClient httpClient, Uri serverUri)
            : base(httpClient, serverUri, "app_store")
        {
                
        }

        public AppStoreRequestBuilder GetBalance(string appUid, string email)
        {
            SetSegments("app_store", "balance");
            UriBuilder.SetQueryParam("app_uid", appUid);
            UriBuilder.SetQueryParam("email", email);

            return this;
        }

        public AppStoreRequestBuilder UseBalance(string appUid, string email, string numberOfCredits)
        {
            SetRequestType(RequestType.Post);
            SetSegments("app_store", "use");
            
            UriBuilder.SetQueryParam("app_uid", appUid);
            UriBuilder.SetQueryParam("email", email);
            UriBuilder.SetQueryParam("num_credits", numberOfCredits);

            return this;
        }

        public async Task<AppStoreResponse> Execute() 
        {
            return await Execute<AppStoreResponse>(BuildUri());
        }

       
    }
}
