using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViamericasChallenge.Server.Common.Exceptions;
using ViamericasChallenge.Server.Common.ViewModels;

namespace ViamericasChallenge.Server.Common.Consumer
{
    public static class Auth
    {

        public static async Task<string> GetNewAccessTokenAsync(string url, LoginRequest data)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(Serialization.SerializeObject(data), Encoding.UTF8, "application/json")
                };
                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                string content = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<LoginResponse>(content);
                return model.id_token;
                //Dictionary<string, string> jsonValues = Serialization.DeserializeObject<Dictionary<string, string>>(content);
                //return jsonValues["id_token"];
            }
            catch (Exception e)
            {
                throw new TokenException(e);
            }
        }
    }
}

