namespace ClientFactory;

using System;
using System.Net.Http;
using System.Threading.Tasks;

public interface IHttpService
{
    Task<HttpResponseMessage> Get(string accessToken, string uri);
    Task<HttpResponseMessage> GetWithTime(string accessToken, string uri, TimeSpan timeout = default(TimeSpan));
    Task<HttpResponseMessage> GetLims(string uri, TimeSpan timeout = default(TimeSpan));
    Task<HttpResponseMessage> Post(string accessToken, string uri, object objValue);
    Task<HttpResponseMessage> Put(string accessToken, string uri, object objValue);
    Task<HttpResponseMessage> Delete(string accessToken, string uri);
}
