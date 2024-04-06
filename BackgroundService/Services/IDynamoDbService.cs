using BackgroundService.Models;

namespace BackgroundService.Services
{
    public interface IDynamoDbService
    {
        Task<List<MyData>> GetList();
    }
}
