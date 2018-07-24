using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class RecommendedDto
    {
        [JsonProperty("champion")]
        public string Champion { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("map")]
        public string Map { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("customTag")]
        public string CustomTag { get; set; }

        [JsonProperty("sortrank")]
        public int SortRank { get; set; }

        [JsonProperty("extensionPage")]
        public bool ExtensionPage { get; set; }

        [JsonProperty("customPanel")]
        public object CustomPanel { get; set; }

        [JsonProperty("blocks")]
        public IList<BlockDto> Blocks { get; set; }
    }
}