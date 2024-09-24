using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Rev.CoreLayer.Entites
{
    public class CustomerBasket
    {
        public string Id { get; set; }

        public  IReadOnlyList<BasketItems> Items { get; set; }

        public CustomerBasket()
        {
            
        }

        public CustomerBasket(string id)
        {
            Id = id;
            Items = new List<BasketItems>();
        }
    }
}
