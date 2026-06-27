namespace BuilderPattern3
{
    public class HttpRequestBuilder : IHttpRequestBuilder
    {
        private HttpMethod _method = null;
        private Uri _uri = null;
        private HttpContent _content = null;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        public IHttpRequestBuilder WithMethod(HttpMethod method)
        {
            _method = method;
            return this;
        }
        public IHttpRequestBuilder WithUri(Uri uri)
        {
            _uri = uri;
            return this;
        }
        public IHttpRequestBuilder WithContent(HttpContent content)
        {
            _content = content;
            return this;
        }
        public IHttpRequestBuilder WithHeader(string name, string value)
        {
            _headers[name] = value;
            return this;
        }
        public HttpRequestMessage Build()
        {
            var message = new HttpRequestMessage(_method, _uri) { Content = _content };

            foreach (var header in _headers)
                message.Headers.Add(header.Key, header.Value);

            return message;
        }
    }
}
