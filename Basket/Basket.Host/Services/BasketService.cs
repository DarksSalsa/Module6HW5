using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.RateLimit.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly IInterserviceCacheService _cacheService;

    public BasketService(IInterserviceCacheService cacheService)
    {
        _cacheService = cacheService;
    }
    
    public async Task TestAdd(string userId, string data)
    {
       await _cacheService.AddOrUpdateAsync(userId, data);
    }

    public async Task<TestGetResponse> TestGet(string userId)
    {
        var result = await _cacheService.GetAsync<string>(userId);
        return new TestGetResponse() { Data = result };
    }
}