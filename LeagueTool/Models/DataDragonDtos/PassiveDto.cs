using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class PassiveDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public ImageDto Image { get; set; }
    }
}