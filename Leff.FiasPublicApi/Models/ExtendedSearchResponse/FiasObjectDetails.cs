using System;
using Newtonsoft.Json;

namespace Leff.FiasPublicApi.Models
{
    public class FiasObjectDetails : FiasObject
    {
        [JsonProperty("ObjectId")]
        public int ObjectId { get; set; }

        [JsonProperty("OperationTypeId")]
        public int OperationTypeId { get; set; }

        [JsonProperty("IsActual")]
        public bool IsActual { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("ChangeId")]
        public int ChangeId { get; set; }

        [JsonProperty("PrevId")]
        public int PrevId { get; set; }

        [JsonProperty("NextId")]
        public int NextId { get; set; }

        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("StartDatetime")]
        public DateTime StartDatetime { get; set; }

        [JsonProperty("EndDatetime")]
        public DateTime EndDatetime { get; set; }

        [JsonProperty("Params")]
        public FiasParameters Parameters { get; set; }

        [JsonProperty("GUID")]
        public Guid Guid { get; set; }

        [JsonProperty("LevelId")]
        public FiasObjectLevelId LevelId { get; set; }

        [JsonProperty("RegionCode")]
        public string RegionCode { get; set; }

        [JsonProperty("ObjType")]
        public string ObjType { get; set; }
    }
}