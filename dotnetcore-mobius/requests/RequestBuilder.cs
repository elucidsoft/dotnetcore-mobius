using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcore_mobius.requests
{
    /// <summary>
    ///     Abstract class for request builders.
    /// </summary>
    public class RequestBuilder<T> where T : class
    {
        private readonly List<string> _segments;
        private bool _segmentsAdded;

        private readonly HttpClient _httpClient;
        protected UriBuilder UriBuilder;
        private string _content = null;

        public enum RequestType {  Post, Get }
        private RequestType _requestType = RequestType.Get;

        public void SetContent(string content)
        {
            _content = content;
        }

        public void SetRequestType(RequestType requestType)
        {
            _requestType = requestType;
        }

        public async Task<TZ> Execute<TZ>(Uri uri) where TZ : class
        {
            var responseHandler = new ResponseHandler<TZ>();

            var response = (_requestType == RequestType.Get) ? _httpClient.GetAsync(uri) : 
                _httpClient.PostAsync(uri, _content  == null ? null : new StringContent(_content, Encoding.UTF8, "application/json"));

            return await responseHandler.HandleResponse(await response);
        }


        public RequestBuilder(HttpClient httpClient, Uri serverUri, string defaultSegment)
        {
            UriBuilder = new UriBuilder(serverUri);
            _segments = new List<string>();
            _httpClient = httpClient;

            if (!string.IsNullOrEmpty(defaultSegment))
                SetSegments(defaultSegment);

            _segmentsAdded = false; //Allow overwriting segments
        }

        protected RequestBuilder<T> SetSegments(params string[] segments)
        {
            if (_segmentsAdded)
                throw new Exception("URL segments have been already added.");

            _segmentsAdded = true;

            //Remove default segments
            _segments.Clear();

            foreach (var segment in segments)
                _segments.Add(segment);

            return this;
        }

        public Uri BuildUri()
        {
            if (_segments.Count <= 0)
                throw new NotSupportedException("No segments defined.");

            var path = _segments.Aggregate("", (current, segment) => current + ("/" + segment));

            UriBuilder.Path += path;

            return UriBuilder.Uri;
        }
    }
}