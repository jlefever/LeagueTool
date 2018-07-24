using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class SkinDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("num")]
        public int Num { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("chromas")]
        public bool Chromas { get; set; }
    }
}