using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    public class ExtendedAdministrativeSearchRequest : ExtendedSearchRequestBase
    {
        [JsonProperty("AdmHierarchy.Region_input")]
        public string RegionInput { get; set; }

        [JsonProperty("AdmHierarchy.Region")]
        public string Region { get; set; }

        [JsonProperty("AdmHierarchy.District_input")]
        public string DistrictInput { get; set; }

        [JsonProperty("AdmHierarchy.District")]
        public string District { get; set; }

        [JsonProperty("AdmHierarchy.City")]
        public string City { get; set; }

        [JsonProperty("AdmHierarchy.IntownTerritory")]
        public string IntownTerritory { get; set; }

        [JsonProperty("AdmHierarchy.Settlement_input")]
        public string SettlementInput { get; set; }

        [JsonProperty("AdmHierarchy.Settlement")]
        public string Settlement { get; set; }

        [JsonProperty("AdmHierarchy.PlanningStructure")]
        public string PlanningStructure { get; set; }

        [JsonProperty("AdmHierarchy.Street_input")]
        public string StreetInput { get; set; }

        [JsonProperty("AdmHierarchy.Street")]
        public string Street { get; set; }

        [JsonProperty("AdmHierarchy.Stead")]
        public string Stead { get; set; }

        [JsonProperty("AdmHierarchy.House")]
        public string House { get; set; }

        [JsonProperty("AdmHierarchy.CarPlace")]
        public string CarPlace { get; set; }

        [JsonProperty("AdmHierarchy.Apartment")]
        public string Apartment { get; set; }

        [JsonProperty("AdmHierarchy.Room")]
        public string Room { get; set; }

        [JsonProperty("AdmHierarchy")]
        private Hierarchy AdministrativeHierarchy => Hierarchy;
    }
}