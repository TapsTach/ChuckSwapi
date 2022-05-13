using System.Text.Json.Serialization;

namespace ChuckSwapi.Models
{
    public class Joke
    {
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }


        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }

        public string Id { get; set; }


        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public string Value { get; set; } 
    }
}
