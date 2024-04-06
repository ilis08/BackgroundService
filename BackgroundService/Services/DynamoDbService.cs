using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using BackgroundService.Models;
using BackgroundService.Settings;
using Microsoft.Extensions.Options;

namespace BackgroundService.Services
{
    public class DynamoDbService : IDynamoDbService
    {
        private readonly IAmazonDynamoDB dynamoDB;
        private readonly IOptions<DynamoDbSettings> dynamoDbSettings;

        public DynamoDbService(IAmazonDynamoDB dynamoDB, IOptions<DynamoDbSettings> dynamoDbSettings)
        {
            this.dynamoDB = dynamoDB;
            this.dynamoDbSettings = dynamoDbSettings;
        }

        public async Task<List<MyData>> GetList()
        {
            var request = new QueryRequest
            {
                TableName = dynamoDbSettings.Value.TableName,
                KeyConditionExpression = "Id = :v_Id",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
        {":v_Id", new AttributeValue { S =  "Amazon DynamoDB#DynamoDB Thread 1" }}}
            };

            var response = await dynamoDB.QueryAsync(request);

            var items = new List<MyData>();

            using (DynamoDBContext dbcontext = new DynamoDBContext(dynamoDB))
            {
                foreach (var item in response.Items)
                {
                    var doc = Document.FromAttributeMap(item);
                    var myModel = dbcontext.FromDocument<MyData>(doc);
                    items.Add(myModel);
                }
            }

            return items;
        }
    }
}
