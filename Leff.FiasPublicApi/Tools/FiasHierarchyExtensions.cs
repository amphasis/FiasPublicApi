using System.Collections.Generic;
using System.Linq;
using Leff.FiasPublicApi.Models;

namespace Leff.FiasPublicApi.Tools
{
    public static class FiasHierarchyExtensions
    {
        internal static string GetQueryStringByLevelId(this FiasHierarchy hierarchy, FiasObjectLevelId levelId,
            bool administrativeHierarchy)
        {
            string isMunicipalHierarchy = administrativeHierarchy ? "false" : "true";

            var parameters = QueryParameterNameByLevelIdDictionary
                .Where(x => x.Key < levelId)
                .Select(x => new {Name = x.Value, Value = hierarchy.GetObjectIdByLevelId(x.Key)})
                .Where(x => x.Value != default)
                .Select(x => $"{x.Name}={x.Value}")
                .Append($"isMunHierarchy={isMunicipalHierarchy}");

            return string.Join("&", parameters);
        }

        private static readonly IReadOnlyDictionary<FiasObjectLevelId, string> QueryParameterNameByLevelIdDictionary =
            new Dictionary<FiasObjectLevelId, string>
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