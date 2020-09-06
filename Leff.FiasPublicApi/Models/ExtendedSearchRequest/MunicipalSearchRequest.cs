using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    public class MunicipalSearchRequest : ExtendedSearchRequestBase
    {
        [JsonProperty("MunHierarchy")]
        private FiasHierarchy MunicipalHierarchy => Hierarchy;
    }
}