using System.Diagnostics;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    [DebuggerDisplay("{Id} {Name}")]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class FiasObject
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}