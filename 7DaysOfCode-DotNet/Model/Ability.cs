using Newtonsoft.Json;

namespace _7DaysOfCode_DotNet.Model
{

    public class Ability
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }
}
