using Amazon.DynamoDBv2.DataModel;
using System.Text.Json.Serialization;

namespace BackgroundService.Models
{
    public class MyData
    {
        [DynamoDBProperty("id")]
        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;

        [DynamoDBProperty("user_name")]
        [JsonPropertyName("user_name")]
        public string Name { get; set; } = default!;

        [DynamoDBProperty("phone_number")]
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = default!;
    }
}
