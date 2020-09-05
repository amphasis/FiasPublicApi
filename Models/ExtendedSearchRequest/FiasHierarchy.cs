using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class FiasHierarchy
    {
        [JsonProperty("Region")]
        public string RegionId { get; set; }

        [JsonProperty("District")]
        public string DistrictId { get; set; }

        [JsonProperty("MunDistrict")]
        public string MunicipalDistrictId { get; set; }

        [JsonProperty("CitySettlement")]
        public string CitySettlementId { get; set; }

        [JsonProperty("City")]
        public string CityId { get; set; }

        [JsonProperty("Settlement")]
        public string SettlementId { get; set; }

        [JsonProperty("PlanningStructure")]
        public string PlanningStructureId { get; set; }

        [JsonProperty("Street")]
        public string StreetId { get; set; }

        [JsonProperty("Stead")]
        public string SteadId { get; set; }

        [JsonProperty("House")]
        public string HouseId { get; set; }

        [JsonProperty("Apartment")]
        public string ApartmentId { get; set; }

        [JsonProperty("Room")]
        public string RoomId { get; set; }

        [JsonProperty("CarPlace")]
        public string CarPlaceId { get; set; }
}
}