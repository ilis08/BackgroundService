using BackgroundService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamoDbController : ControllerBase
    {
        private readonly IDynamoDbService dynamoDbService;

        public DynamoDbController(IDynamoDbService dynamoDbService)
        {
            this.dynamoDbService = dynamoDbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await dynamoDbService.GetList();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            var result = await dynamoDbService.DeleteById(id);

            return Ok(result);
        }
    }
}
