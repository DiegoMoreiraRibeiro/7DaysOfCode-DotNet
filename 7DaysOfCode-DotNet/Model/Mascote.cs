using Newtonsoft.Json;

namespace _7DaysOfCode_DotNet.Model
{
    public class Mascote
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("height")]
        public string height { get; set; }

        [JsonProperty("weight")]
        public string weight { get; set; }

        [JsonProperty("abilities")]
        public List<Abilities> Abilities { get; set; }
    }
}
