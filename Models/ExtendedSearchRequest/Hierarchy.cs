using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Hierarchy
    {
        [JsonProperty("Region")]
        public string Region { get; set; }

        [JsonProperty("District")]
        public string District { get; set; }

        [JsonProperty("MunDistrict")]
        private string MunDistrict => District;

        [JsonProperty("CitySettlement")]
        public string CitySettlement { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("Settlement")]
        public string Settlement { get; set; }

        [JsonProperty("PlanningStructure")]
        public string PlanningStructure { get; set; }

        [JsonProperty("Street")]
        public string Street { get; set; }

        [JsonProperty("House")]
        public string House { get; set; }

        [JsonProperty("Stead")]
        public string Stead { get; set; }
    }
}