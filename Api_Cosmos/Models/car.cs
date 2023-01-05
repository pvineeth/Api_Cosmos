using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Api_Cosmos.Models
{
    public class car
    {
        [JsonProperty("id")]
        public string  ID { get; set; }

        [JsonProperty("Make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }
    }
}
