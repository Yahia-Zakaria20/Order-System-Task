using OrderSystem.CoreLayer.RepositoryLayer.Contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.RepositoryLayer
{
    public class BasketRepositry : IBasketRepositry
    {
        private readonly IDatabase _database;

        public BasketRepositry(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }


        public async Task<bool> DeleteCustomerBasketAsync(string Id)
        {
           return  await _database.KeyDeleteAsync(Id);
        }

        public async Task<CustomerBasket> GetCustomerBasketAsync(string Id)
        {
            //get by id 

           var Basket =  await  _database.StringGetAsync(Id);

            if (!Basket.IsNullOrEmpty) 
            {
                //transfare the object from json to customerbasket

                var CustomerBasket = JsonSerializer.Deserialize<CustomerBasket>(Basket);

                return CustomerBasket;
            }

            return null;
          

          
        }

        public async Task<CustomerBasket> UpdateCustomerBasketAsync(CustomerBasket basket)
        { 

         var Result = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (!Result)
                return null;

            return await GetCustomerBasketAsync(basket.Id);
        }
    }
}
