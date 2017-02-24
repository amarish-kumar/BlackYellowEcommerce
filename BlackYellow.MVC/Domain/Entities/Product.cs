using System;
using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int  Quantity { get; set; }
        public double LastPrice { get; set; }
        public double Price { get; set; }
        public Category Category{get; set;}
        public DateTime DateRegister{get; set;}
        public List<GaleryProduct> GaleryProduct{get; set;}




        public bool GaleryIsFull()
        {
            return GaleryProduct.Count >= 4;
        }

        public bool isAvailable()
        {
            return Quantity > 0;
        }
    }
}