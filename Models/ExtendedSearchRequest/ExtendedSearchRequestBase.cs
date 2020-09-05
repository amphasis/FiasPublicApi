using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    public abstract class ExtendedSearchRequestBase : SearchRequestBase
    {
        [JsonProperty("PostalIndex")]
        public string PostalIndex { get; set; }

        [JsonProperty("OkatoCode")]
        public string OkatoCode { get; set; }

        [JsonProperty("OkatoComboBox")]
        public string OkatoComboBox { get; set; }

        [JsonProperty("Section")]
        public string Section { get; set; }

        [JsonProperty("OktmoCode")]
        public string OktmoCode { get; set; }

        [JsonProperty("OktmoComboBox")]
        public string OktmoComboBox { get; set; }

        [JsonProperty("CadastrNumber")]
        public string CadastrNumber { get; set; }

        [JsonProperty("OnlyActiveObjects")]
        public string OnlyActiveObjects { get; set; }

        [JsonProperty("ObjectLevelFias")]
        public string ObjectLevelFias { get; set; }

        [JsonIgnore]
        public Hierarchy Hierarchy { get; set; }
    }
}