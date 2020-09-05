using System;
using Leff.FiasPublicApi.Models;

namespace Leff.FiasPublicApi.Tools
{
    internal static class FiasObjectLevelIdExtensions
    {
        public static string GetChildObjectSearchEndpointName(this FiasObjectLevelId levelId,
            bool administrativeHierarchy = false)
        {
            switch (levelId)
            {
                case FiasObjectLevelId.Region:
                    return "GetRegions";
                case FiasObjectLevelId.District:
                    return "GetDistricts";
                case FiasObjectLevelId.MunicipalDistrict:
                    return "GetMunDistricts";
                case FiasObjectLevelId.CitySettlement:
                    return administrativeHierarchy ? "GetCitySettlements" : "GetMunCitySettlements";
                case FiasObjectLevelId.City:
                    return administrativeHierarchy ? "GetCities" : "GetMunCities";
                case FiasObjectLevelId.Settlement:
                    return administrativeHierarchy ? "GetSettlements" : "GetMunSettlements";
                case FiasObjectLevelId.PlanStructure:
                    return administrativeHierarchy ? "GetPlanStructures" : "GetMunPlanStructures";
                case FiasObjectLevelId.Street:
                    return administrativeHierarchy ? "GetStreets" : "GetMunStreets";
                case FiasObjectLevelId.Stead:
                    return administrativeHierarchy ? "GetSteads" : "GetMunSteads";
                case FiasObjectLevelId.House:
                    return administrativeHierarchy ? "GetHouses" : "GetMunHouses";
                case FiasObjectLevelId.Apartment:
                    return "GetApartments";
                case FiasObjectLevelId.Room:
                    return "GetRooms";
                case FiasObjectLevelId.CarPlace:
                    return "GetCarPlaces";
                default:
                    throw new ArgumentOutOfRangeException(nameof(levelId), levelId, message: null);
            }
        }
    }
}