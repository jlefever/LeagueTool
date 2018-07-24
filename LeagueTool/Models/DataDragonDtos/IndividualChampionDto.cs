using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class IndividualChampionDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("data")]
        public IDictionary<string, FullChampionDto> Data { get; set; }
    }
}