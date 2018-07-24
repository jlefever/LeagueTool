using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class LevelTipDto
    {
        [JsonProperty("label")]
        public IList<string> Label { get; set; }

        [JsonProperty("effect")]
        public IList<string> Effect { get; set; }
    }
}