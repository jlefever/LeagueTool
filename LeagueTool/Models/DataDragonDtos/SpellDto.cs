using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class SpellDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tooltip")]
        public string ToolTip { get; set; }

        [JsonProperty("leveltip")]
        public LevelTipDto LevelTip { get; set; }

        [JsonProperty("maxrank")]
        public int MaxRank { get; set; }

        [JsonProperty("cooldown")]
        public IList<double> Cooldown { get; set; }

        [JsonProperty("cooldownBurn")]
        public string CooldownBurn { get; set; }

        [JsonProperty("cost")]
        public IList<int> Cost { get; set; }

        [JsonProperty("costBurn")]
        public string CostBurn { get; set; }

        [JsonProperty("effect")]
        public IList<IList<double>> Effect { get; set; }

        [JsonProperty("effectBurn")]
        public IList<string> EffectBurn { get; set; }

        [JsonProperty("vars")]
        public IList<VarDto> Vars { get; set; }

        [JsonProperty("costType")]
        public string CostType { get; set; }

        [JsonProperty("maxammo")]
        public string MaxAmmo { get; set; }

        [JsonProperty("range")]
        public IList<int> Range { get; set; }

        [JsonProperty("rangeBurn")]
        public string RangeBurn { get; set; }

        [JsonProperty("image")]
        public ImageDto Image { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }
    }
}