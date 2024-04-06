using System.Text.Json.Serialization;

namespace BackgroundService.Models
{
    public class MyData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = default!;
    }
}
