using System.ComponentModel.DataAnnotations;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.Dtos
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }

        public IReadOnlyList<BasketItems> Items { get; set; }

        public CustomerBasketDto()
        {

        }

        public CustomerBasketDto(string id)
        {
            Id = id;
            Items = new List<BasketItems>();
        }
    }
}
