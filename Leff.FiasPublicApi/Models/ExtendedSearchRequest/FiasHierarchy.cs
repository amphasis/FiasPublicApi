using System;
using Leff.FiasPublicApi.Tools;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class FiasHierarchy
    {
        public FiasHierarchy()
        {
        }

        public FiasHierarchy(FiasObjectLevelId levelId, int objectId)
        {
            SetObjectIdByLevelId(levelId, objectId);
        }

        [JsonProperty("Region", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int RegionId { get; set; }

        [JsonProperty("District", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int DistrictId { get; set; }

        [JsonProperty("MunDistrict", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int MunicipalDistrictId { get; set; }

        [JsonProperty("CitySettlement", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int CitySettlementId { get; set; }

        [JsonProperty("City", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int CityId { get; set; }

        [JsonProperty("Settlement", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int SettlementId { get; set; }

        [JsonProperty("PlanningStructure", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int PlanningStructureId { get; set; }

        [JsonProperty("Street", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int StreetId { get; set; }

        [JsonProperty("Stead", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int SteadId { get; set; }

        [JsonProperty("House", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int HouseId { get; set; }

        [JsonProperty("Apartment", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int ApartmentId { get; set; }

        [JsonProperty("Room", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int RoomId { get; set; }

        [JsonProperty("CarPlace", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(IntToStringConverter))]
        public int CarPlaceId { get; set; }

        public int GetObjectIdByLevelId(FiasObjectLevelId levelId)
        {
            switch (levelId)
            {
                case FiasObjectLevelId.Region:
                    return RegionId;
                case FiasObjectLevelId.District:
                    return DistrictId;
                case FiasObjectLevelId.MunicipalDistrict:
                    return MunicipalDistrictId;
                case FiasObjectLevelId.CitySettlement:
                    return CitySettlementId;
                case FiasObjectLevelId.City:
                    return CityId;
                case FiasObjectLevelId.Settlement:
                    return SettlementId;
                case FiasObjectLevelId.PlanStructure:
                    return PlanningStructureId;
                case FiasObjectLevelId.Street:
                    return StreetId;
                case FiasObjectLevelId.Stead:
                    return SteadId;
                case FiasObjectLevelId.House:
                    return HouseId;
                case FiasObjectLevelId.Apartment:
                    return ApartmentId;
                case FiasObjectLevelId.Room:
                    return RoomId;
                case FiasObjectLevelId.CarPlace:
                    return CarPlaceId;
                default:
                    throw new ArgumentOutOfRangeException(nameof(levelId), levelId, message: null);
            }
        }

        public FiasHierarchy SetObjectIdByLevelId(FiasObjectLevelId levelId, int objectId)
        {
            switch (levelId)
            {
                case FiasObjectLevelId.Region:
                    RegionId = objectId;
                    break;
                case FiasObjectLevelId.District:
                    DistrictId = objectId;
                    break;
                case FiasObjectLevelId.MunicipalDistrict:
                    MunicipalDistrictId = objectId;
                    break;
                case FiasObjectLevelId.CitySettlement:
                    CitySettlementId = objectId;
                    break;
                case FiasObjectLevelId.City:
                    CityId = objectId;
                    break;
                case FiasObjectLevelId.Settlement:
                    SettlementId = objectId;
                    break;
                case FiasObjectLevelId.PlanStructure:
                    PlanningStructureId = objectId;
                    break;
                case FiasObjectLevelId.Street:
                    StreetId = objectId;
                    break;
                case FiasObjectLevelId.Stead:
                    SteadId = objectId;
                    break;
                case FiasObjectLevelId.House:
                    HouseId = objectId;
                    break;
                case FiasObjectLevelId.Apartment:
                    ApartmentId = objectId;
                    break;
                case FiasObjectLevelId.Room:
                    RoomId = objectId;
                    break;
                case FiasObjectLevelId.CarPlace:
                    CarPlaceId = objectId;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(levelId), levelId, message: null);
            }

            return this;
        }
    }
}