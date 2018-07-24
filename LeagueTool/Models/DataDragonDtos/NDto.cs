using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class NDto
    {
        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("rune")]
        public string Rune { get; set; }

        [JsonProperty("mastery")]
        public string Mastery { get; set; }

        [JsonProperty("summoner")]
        public string Summoner { get; set; }

        [JsonProperty("champion")]
        public string Champion { get; set; }

        [JsonProperty("profileicon")]
        public string Profileicon { get; set; }

        [JsonProperty("map")]
        public string Map { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("sticker")]
        public string Sticker { get; set; }
    }
}