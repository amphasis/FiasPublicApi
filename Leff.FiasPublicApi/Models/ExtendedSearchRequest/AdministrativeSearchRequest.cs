using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    public class AdministrativeSearchRequest : ExtendedSearchRequestBase
    {
        [JsonProperty("AdmHierarchy")]
        private FiasHierarchy AdministrativeHierarchy => Hierarchy;
    }
}