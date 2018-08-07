using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class VarDto
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}