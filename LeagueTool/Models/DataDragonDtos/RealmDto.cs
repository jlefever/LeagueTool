using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class RealmDto
    {
        [JsonProperty("n")]
        public NDto N { get; set; }

        [JsonProperty("v")]
        public string V { get; set; }

        [JsonProperty("l")]
        public string L { get; set; }

        [JsonProperty("cdn")]
        public string Cdn { get; set; }

        [JsonProperty("dd")]
        public string Dd { get; set; }

        [JsonProperty("lg")]
        public string Lg { get; set; }

        [JsonProperty("css")]
        public string Css { get; set; }

        [JsonProperty("profileiconmax")]
        public int Profileiconmax { get; set; }

        [JsonProperty("store")]
        public object Store { get; set; }
    }
}