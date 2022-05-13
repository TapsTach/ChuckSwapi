
namespace ChuckSwapi.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }
        
        public string Gender { get; set; }

    }
}
