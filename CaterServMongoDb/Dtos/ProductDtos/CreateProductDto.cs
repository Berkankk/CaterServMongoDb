﻿namespace CaterServMongoDb.Dtos.ProductDtos
{
    public class CreateProductDto
    {
     
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }
        public bool IsVegetarian { get; set; }
        public IFormFile File { get; set; }
        public string CategoryID { get; set; }
    }
}
