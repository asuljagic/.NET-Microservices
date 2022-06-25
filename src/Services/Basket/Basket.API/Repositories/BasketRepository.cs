using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        //best practice when working with Redis or distributed cache
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        
        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if(String.IsNullOrEmpty(basket))
                return null;

            //Deserializing String to Shopping Cart object
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }


        //This method cover all operations of shopping cart addd item,
        //remove item, create shopping cart
        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            //overrides all information if there is existing username
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }
    }
}
