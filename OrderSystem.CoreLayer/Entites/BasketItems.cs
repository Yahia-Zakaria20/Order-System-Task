using System.ComponentModel.DataAnnotations;

namespace Talabat.Rev.CoreLayer.Entites
{
    public class BasketItems
    {
        [Required]
        public int Id {  get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Quantity { get; set; } 


    }
}