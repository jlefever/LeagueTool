using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class BlockDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("recMath")]
        public bool RecMath { get; set; }

        [JsonProperty("recSteps")]
        public bool RecSteps { get; set; }

        [JsonProperty("minSummonerLevel")]
        public int MinSummonerLevel { get; set; }

        [JsonProperty("maxSummonerLevel")]
        public int MaxSummonerLevel { get; set; }

        [JsonProperty("showIfSummonerSpell")]
        public string ShowIfSummonerSpell { get; set; }

        [JsonProperty("hideIfSummonerSpell")]
        public string HideIfSummonerSpell { get; set; }

        [JsonProperty("items")]
        public IList<ItemDto> Items { get; set; }
    }
}