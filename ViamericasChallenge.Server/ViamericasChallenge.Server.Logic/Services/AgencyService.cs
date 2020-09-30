using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ViamericasChallenge.Server.Common;
using ViamericasChallenge.Server.Common.Consumer;
using ViamericasChallenge.Server.Common.ViewModels;

namespace ViamericasChallenge.Server.Logic.Services
{
    public class AgencyService
    {
        public static async Task<List<AgencyResponse>> GetAgencyAsync()
        {
            string uri = UrlServices.URL_AGENCY;
            Consumer<AgencyResponse> consumer = new Consumer<AgencyResponse>();
            HttpResponseMessage response = await consumer.Get(uri);
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return Serialization.DeserializeObject<List<AgencyResponse>>(content);
        }
    }
}
