using System;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SearchRequestBase
    {
        public SearchRequestBase()
        {
            Take = 5;
        }

        [JsonProperty("Division")]
        private string Division => "1";

        [JsonIgnore]
        public Guid? Guid { get; set; }

        [JsonProperty("GUID")]
        private string SerializableGuid => Guid?.ToString() ?? "";

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("take")]
        public int Take { get; set; }
    }
}