using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.CoreLayer.RepositoryLayer.Contract
{
    public interface IBasketRepositry
    {
        Task<CustomerBasket?> GetCustomerBasketAsync(string Id);

        Task<CustomerBasket?> UpdateCustomerBasketAsync(CustomerBasket basket);

        Task<bool> DeleteCustomerBasketAsync(string Id); 


    }
}
