﻿namespace Inventory.Infrastructure.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; } 

        public string CategoryName { get; set; }


    }
}
