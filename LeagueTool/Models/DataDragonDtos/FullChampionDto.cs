using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class FullChampionDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public ImageDto Image { get; set; }

        [JsonProperty("skins")]
        public IList<SkinDto> Skins { get; set; }

        [JsonProperty("lore")]
        public string Lore { get; set; }

        [JsonProperty("blurb")]
        public string Blurb { get; set; }

        [JsonProperty("allytips")]
        public IList<string> AllyTips { get; set; }

        [JsonProperty("enemytips")]
        public IList<string> EnemyTips { get; set; }

        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        [JsonProperty("partype")]
        public string Partype { get; set; }

        [JsonProperty("info")]
        public InfoDto Info { get; set; }

        [JsonProperty("stats")]
        public StatsDto Stats { get; set; }

        [JsonProperty("passive")]
        public PassiveDto Passive { get; set; }
    }
}