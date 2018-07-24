using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class StatsDto
    {
        [JsonProperty("hp")]
        public double Hp { get; set; }

        [JsonProperty("hpperlevel")]
        public double HpPerLevel { get; set; }

        [JsonProperty("mp")]
        public double Mp { get; set; }

        [JsonProperty("mpperlevel")]
        public double MpPerLevel { get; set; }

        [JsonProperty("movespeed")]
        public double MoveSpeed { get; set; }

        [JsonProperty("armor")]
        public double Armor { get; set; }

        [JsonProperty("armorperlevel")]
        public double ArmorPerLevel { get; set; }

        [JsonProperty("spellblock")]
        public double SpellBlock { get; set; }

        [JsonProperty("spellblockperlevel")]
        public double SpellBlockPerLevel { get; set; }

        [JsonProperty("attackrange")]
        public double AttackRange { get; set; }

        [JsonProperty("hpregen")]
        public double HpRegen { get; set; }

        [JsonProperty("hpregenperlevel")]
        public double HpRegenPerLevel { get; set; }

        [JsonProperty("mpregen")]
        public double MpRegen { get; set; }

        [JsonProperty("mpregenperlevel")]
        public double MpRegenPerLevel { get; set; }

        [JsonProperty("crit")]
        public double Crit { get; set; }

        [JsonProperty("critperlevel")]
        public double CritPerLevel { get; set; }

        [JsonProperty("attackdamage")]
        public double AttackDamage { get; set; }

        [JsonProperty("attackdamageperlevel")]
        public double AttackDamagePerLevel { get; set; }

        [JsonProperty("attackspeedoffset")]
        public double AttackSpeedOffset { get; set; }

        [JsonProperty("attackspeedperlevel")]
        public double AttackSpeedPerLevel { get; set; }
    }
}