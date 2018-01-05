using System;
using System.Net.Http;
using dotnetcore_mobius.requests;

namespace dotnetcore_mobius
{
    public class Server : IDisposable
    {
        private readonly Uri _serverUri;

        public Server(string uri, string apiKey)
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

            _serverUri = new Uri(uri);
        }
        
        public HttpClient HttpClient { get; set; }

        public AppStoreRequestBuilder AppStore => new AppStoreRequestBuilder(HttpClient, _serverUri);
        public DataFeedRequestBuilder DataFeed => new DataFeedRequestBuilder(HttpClient, _serverUri);
        public TokensRequestBuilder Tokens => new TokensRequestBuilder(HttpClient, _serverUri);
        
        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
