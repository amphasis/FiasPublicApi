using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using Leff.FiasPublicApi.Models;

namespace Leff.FiasPublicApi.Tools
{
    public static class FiasHierarchyExtensions
    {
        public static string GetObjectIdByLevelId(this FiasHierarchy fiasHierarchy, FiasObjectLevelId levelId)
        {
            if (fiasHierarchy == null) throw new ArgumentNullException(nameof(fiasHierarchy));

            switch (levelId)
            {
                case FiasObjectLevelId.Region:
                    return fiasHierarchy.RegionId;
                case FiasObjectLevelId.District:
                    return fiasHierarchy.DistrictId;
                case FiasObjectLevelId.MunicipalDistrict:
                    return fiasHierarchy.MunicipalDistrictId;
                case FiasObjectLevelId.CitySettlement:
                    return fiasHierarchy.CitySettlementId;
                case FiasObjectLevelId.City:
                    return fiasHierarchy.CityId;
                case FiasObjectLevelId.Settlement:
                    return fiasHierarchy.SettlementId;
                case FiasObjectLevelId.PlanStructure:
                    return fiasHierarchy.PlanningStructureId;
                case FiasObjectLevelId.Street:
                    return fiasHierarchy.StreetId;
                case FiasObjectLevelId.Stead:
                    return fiasHierarchy.SteadId;
                case FiasObjectLevelId.House:
                    return fiasHierarchy.HouseId;
                case FiasObjectLevelId.Apartment:
                    return fiasHierarchy.ApartmentId;
                case FiasObjectLevelId.Room:
                    return fiasHierarchy.RoomId;
                case FiasObjectLevelId.CarPlace:
                    return fiasHierarchy.CarPlaceId;
                default:
                    throw new ArgumentOutOfRangeException(nameof(levelId), levelId, message: null);
            }
        }

        public static FiasHierarchy SetObjectIdByLevelId(this FiasHierarchy fiasHierarchy, FiasObjectLevelId levelId, string objectId)
        {
            if (fiasHierarchy == null) throw new ArgumentNullException(nameof(fiasHierarchy));

            switch (levelId)
            {
                case FiasObjectLevelId.Region:
                    fiasHierarchy.RegionId = objectId;
                    break;
                case FiasObjectLevelId.District:
                    fiasHierarchy.DistrictId = objectId;
                    break;
                case FiasObjectLevelId.MunicipalDistrict:
                    fiasHierarchy.MunicipalDistrictId = objectId;
                    break;
                case FiasObjectLevelId.CitySettlement:
                    fiasHierarchy.CitySettlementId = objectId;
                    break;
                case FiasObjectLevelId.City:
                    fiasHierarchy.CityId = objectId;
                    break;
                case FiasObjectLevelId.Settlement:
                    fiasHierarchy.SettlementId = objectId;
                    break;
                case FiasObjectLevelId.PlanStructure:
                    fiasHierarchy.PlanningStructureId = objectId;
                    break;
                case FiasObjectLevelId.Street:
                    fiasHierarchy.StreetId = objectId;
                    break;
                case FiasObjectLevelId.Stead:
                    fiasHierarchy.SteadId = objectId;
                    break;
                case FiasObjectLevelId.House:
                    fiasHierarchy.HouseId = objectId;
                    break;
                case FiasObjectLevelId.Apartment:
                    fiasHierarchy.ApartmentId = objectId;
                    break;
                case FiasObjectLevelId.Room:
                    fiasHierarchy.RoomId = objectId;
                    break;
                case FiasObjectLevelId.CarPlace:
                    fiasHierarchy.CarPlaceId = objectId;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(levelId), levelId, message: null);
            }

            return fiasHierarchy;
        }

        internal static string GetQueryStringByLevelId(this FiasHierarchy hierarchy, FiasObjectLevelId levelId)
        {
            var parameters = QueryParameterNameByLevelIdDictionary
                .Where(x => x.Key < levelId)
                .Select(x => new {Name = x.Value, Value = hierarchy.GetObjectIdByLevelId(x.Key)})
                .Where(x => !string.IsNullOrWhiteSpace(x.Value))
                .Select(x => $"{x.Name}={HttpUtility.UrlEncode(x.Value)}");

            return string.Join("&", parameters);
        }

        private static readonly IReadOnlyDictionary<FiasObjectLevelId, string> QueryParameterNameByLevelIdDictionary =
            new Dictionary<FiasObjectLevelId, string>()
            {
                {FiasObjectLevelId.Region, "regionId"},
                {FiasObjectLevelId.District, "districtId"},
                {FiasObjectLevelId.MunicipalDistrict, "munDistrictId"},
                {FiasObjectLevelId.CitySettlement, "citySettlementId"},
                {FiasObjectLevelId.City, "cityId"},
                {FiasObjectLevelId.Settlement, "settlementId"},
                {FiasObjectLevelId.PlanStructure, "planStructId"},
                {FiasObjectLevelId.Street, "streetId"},
                {FiasObjectLevelId.House, "houseId"},
                {FiasObjectLevelId.Apartment, "apartmentId"}
            };
    }
}