using Newtonsoft.Json;

namespace ViamericasChallenge.Server.Common
{
    public class Serialization
    {
        public static T DeserializeObject<T>(string texto)
        {
            return JsonConvert.DeserializeObject<T>(texto);
        }

        public static string SerializeObject<T>(T item)
        {
            return JsonConvert.SerializeObject(item);
        }
    }
}
