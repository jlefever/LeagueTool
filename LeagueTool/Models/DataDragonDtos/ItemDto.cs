using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class ItemDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("hideCount")]
        public bool HideCount { get; set; }
    }
}