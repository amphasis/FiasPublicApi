using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    public class ExtendedMunicipalSearchRequest : ExtendedSearchRequestBase
    {
        [JsonProperty("MunHierarchy.Region_input")]
        public string RegionInput { get; set; }

        [JsonProperty("MunHierarchy.Region")]
        public string Region { get; set; }

        [JsonProperty("MunHierarchy.MunDistrict_input")]
        public string MunDistrictInput { get; set; }

        [JsonProperty("MunHierarchy.MunDistrict")]
        public string MunDistrict { get; set; }

        [JsonProperty("MunHierarchy.CitySettlement_input")]
        public string CitySettlementInput { get; set; }

        [JsonProperty("MunHierarchy.CitySettlement")]
        public string CitySettlement { get; set; }

        [JsonProperty("MunHierarchy.City")]
        public string City { get; set; }

        [JsonProperty("MunHierarchy.Settlement_input")]
        public string SettlementInput { get; set; }

        [JsonProperty("MunHierarchy.Settlement")]
        public string Settlement { get; set; }

        [JsonProperty("MunHierarchy.IntownTerritory")]
        public string IntownTerritory { get; set; }

        [JsonProperty("MunHierarchy.PlanningStructure")]
        public string PlanningStructure { get; set; }

        [JsonProperty("MunHierarchy.Street")]
        public string Street { get; set; }
        [JsonProperty("MunHierarchy.Stead")]
        public string Stead { get; set; }
        [JsonProperty("MunHierarchy.House")]
        public string House { get; set; }

        [JsonProperty("MunHierarchy.CarPlace")]
        public string CarPlace { get; set; }

        [JsonProperty("MunHierarchy.Apartment")]
        public string Apartment { get; set; }

        [JsonProperty("MunHierarchy.Room")]
        public string Room { get; set; }
 
        [JsonProperty("MunHierarchy")]
        private FiasHierarchy MunicipalHierarchy => Hierarchy;
   }
}