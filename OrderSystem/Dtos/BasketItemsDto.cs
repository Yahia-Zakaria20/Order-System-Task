﻿namespace OrderSystem.Dtos
{
    public class BasketItemsDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Brand { get; set; }

        public int Quantity { get; set; }

    }
}
