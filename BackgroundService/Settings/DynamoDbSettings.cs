namespace BackgroundService.Settings
{
    public class DynamoDbSettings
    {
        public const string KeyName = "Database";

        public string TableName { get; set; } = default!;
    }
}
