using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace BlackYellow.MVC.Domain.Entites
{
    public class Product
    {

        public Product()
        {
            this.GaleryProduct = new List<GaleryProduct>();
        }
        [Key]
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
     //   public double LastPrice { get; set; }
        public double Price { get; set; }
        [Write(false)]
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public DateTime DateRegister { get; set; }
        [Write(false)]
        public List<GaleryProduct> GaleryProduct { get; set; }

        [Write(false)]
        public bool IsAvailable
        {
            get
            {
                return Quantity > 0;
            }
        }


       
        public bool GaleryIsFull()
        {
            return GaleryProduct.Count >= 4;
        }

       


        public void FileGalery(IFormFile main_file, ICollection<IFormFile> details_files, string path)
        {
            GaleryProduct galeryPrincipal = new GaleryProduct(path, main_file.Name, true);
            GaleryProduct = new List<GaleryProduct>();
            GaleryProduct.Add(galeryPrincipal);
            foreach (var file in details_files)
            {
                GaleryProduct galeryDetails = new GaleryProduct(path, file.Name, false);
                GaleryProduct.Add(galeryDetails);
            }
        }
    }
}