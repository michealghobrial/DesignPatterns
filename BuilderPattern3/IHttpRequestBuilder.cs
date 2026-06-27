using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern3
{
    public interface IHttpRequestBuilder
    {
        IHttpRequestBuilder WithMethod(HttpMethod method);
        IHttpRequestBuilder WithUri(Uri uri);
        IHttpRequestBuilder WithContent(HttpContent content);
        IHttpRequestBuilder WithHeader(string name, string value);
        HttpRequestMessage Build();
    }
}
