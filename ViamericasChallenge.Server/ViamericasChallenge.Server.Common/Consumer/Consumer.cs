using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViamericasChallenge.Server.Common.ViewModels;

namespace ViamericasChallenge.Server.Common.Consumer
{
    public class Consumer<T> : ConsumerBase<T>
    {

        protected override async Task<HttpClient> GetClientAsync()
        {
            HttpClient client = new HttpClient();

            string token = await Auth.GetNewAccessTokenAsync(UrlServices.URL_LOGIN, GetLoginData());
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthData.BEARER, token);
            return client;
        }

        private LoginRequest GetLoginData()
        {
            return new LoginRequest("techuser", "TechUser123");
        }
    }
}
