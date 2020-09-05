using System.Collections.Generic;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExtendedSearchResponse
    {
        [JsonProperty("Data")]
        public IList<FiasObjectDetails> Data { get; set; }

        [JsonProperty("Total")]
        public int Total { get; set; }

        [JsonProperty("AggregateResults")]
        public IList<object> AggregateResults { get; set; }

        [JsonProperty("Errors")]
        public IList<object> Errors { get; set; }
    }
}