using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Tools
{
    internal class JsonContent : StringContent
    {
        public const string MediaType = "application/json";

        public JsonContent(object content) : base(Serialize(content), Encoding.UTF8, MediaType)
        {
        }

        private static string Serialize(object content)
        {
            string serializedContent = JsonConvert.SerializeObject(content);
            return serializedContent;
        }
    }
}