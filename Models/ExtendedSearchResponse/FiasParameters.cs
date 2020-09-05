using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class FiasParameters
    {
        [JsonProperty("TerritorialIfnsFlCode")]
        public string TerritorialIfnsFlCode { get; set; }

        [JsonProperty("TerritorialIfnsUlCode")]
        public string TerritorialIfnsUlCode { get; set; }

        [JsonProperty("IFNSUL")]
        public string IFNSUL { get; set; }

        [JsonProperty("IFNSFL")]
        public string IFNSFL { get; set; }

        [JsonProperty("PostIndex")]
        public string PostIndex { get; set; }

        [JsonProperty("OKATO")]
        public string OKATO { get; set; }

        [JsonProperty("OKTMO")]
        public string OKTMO { get; set; }

        [JsonProperty("CadastrNum")]
        public object CadastrNum { get; set; }

        [JsonProperty("RegionCode")]
        public object RegionCode { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("PlainCode")]
        public string PlainCode { get; set; }

        [JsonProperty("ReesterNum")]
        public string ReesterNum { get; set; }

        [JsonProperty("OfficialName")]
        public object OfficialName { get; set; }
    }
}