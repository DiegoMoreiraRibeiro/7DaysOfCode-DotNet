using Newtonsoft.Json;

namespace _7DaysOfCode_DotNet.Model
{
    public class Abilities
    {
        [JsonProperty("ability")]
        public Ability Ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }
}
