using System.Collections.Generic;
using System.Linq;
using RiotNet.Models;

namespace LeagueTool.Models
{
    public class Platform
    {
        public string Value { get; }

        private Platform(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public static IEnumerable<Platform> All()
        {
            return PlatformId.All.Select(p => new Platform(p));
        }
    }
}