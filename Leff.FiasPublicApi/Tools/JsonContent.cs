using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Tools
{
    internal class JsonContent : StringContent
    {
        public const string MediaType = "application/json";

        public JsonContent(object content) : base(JsonConvert.SerializeObject(content), Encoding.UTF8, MediaType)
        {
        }
    }
}