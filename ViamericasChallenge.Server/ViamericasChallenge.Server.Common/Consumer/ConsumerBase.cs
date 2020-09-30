using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ViamericasChallenge.Server.Common.Consumer
{
    public abstract class ConsumerBase<T>
    {
        protected abstract Task<HttpClient> GetClientAsync();

        public async Task<HttpResponseMessage> Post(T data, string uri)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(uri),
                    Content = new StringContent(Serialization.SerializeObject(data), Encoding.UTF8, "application/json")
                };
                using (HttpClient client = await GetClientAsync())
                {
                    HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                        throw new Exception("Acceso denegado");
                    return response;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<HttpResponseMessage> Get(string uri, string query = null)
        {
            try
            {
                UriBuilder baseUri = new UriBuilder(uri);
                if (!string.IsNullOrEmpty(query))
                    baseUri.Query = query;
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = baseUri.Uri
                };
                using (HttpClient client = await GetClientAsync())
                {
                    HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                    if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                        throw new Exception("Acceso denegado");
                    return response;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}