using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SearchRequestBase
    {
        [JsonProperty("GUID")]
        public string Guid { get; set; }

        [JsonProperty("Division")]
        public string Division { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("take")]
        public int Take { get; set; }
    }
}