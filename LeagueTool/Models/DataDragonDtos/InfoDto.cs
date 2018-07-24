﻿using Newtonsoft.Json;

namespace LeagueTool.Models.DataDragonDtos
{
    public class InfoDto
    {
        [JsonProperty("attack")]
        public int Attack { get; set; }

        [JsonProperty("defense")]
        public int Defense { get; set; }

        [JsonProperty("magic")]
        public int Magic { get; set; }

        [JsonProperty("difficulty")]
        public int Difficulty { get; set; }
    }
}