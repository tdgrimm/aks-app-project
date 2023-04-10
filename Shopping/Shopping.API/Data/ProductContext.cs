using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shopping.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public IMongoCollection<Product> Products { get; }
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var db = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = db.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);

            SeedData(Products);
           
            
        }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {

            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone X",
                    Description = "IPhone X is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Samsung 10",
                    Description = "Samsung 10 is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description = "Huawei Plus is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "Xiaomi Mi 9 is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Description = "HTC U11+ Plus is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "LG G7 ThinQ EndofCourse",
                    Description = "LG G7 ThinQ EndofCourse is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                }
            };
        }



        #region Static Data
        //public static readonly List<Product> Products = new List<Product>
        //{

        //new Product()
        //{
        //    Name = "IPhone X",
        //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //    ImageFile = "product-1.png",
        //    Price = 950.00M,
        //    Category = "Smart Phone"
        //},
        //new Product()
        //{
        //    Name = "Samsung 10",
        //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //    ImageFile = "product-2.png",
        //    Price = 840.00M,
        //    Category = "Smart Phone"
        //},
        //new Product()
        //{
        //    Name = "Huawei Plus",
        //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //    ImageFile = "product-3.png",
        //    Price = 650.00M,
        //    Category = "White Appliances"
        //},
        //new Product()
        //{
        //    Name = "Xiaomi Mi 9",
        //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //    ImageFile = "product-4.png",
        //    Price = 470.00M,
        //    Category = "White Appliances"
        //},
        //new Product()
        //{
        //    Name = "HTC U11+ Plus",
        //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //    ImageFile = "product-5.png",
        //    Price = 380.00M,
        //    Category = "Smart Phone"
        //},
        //new Product()
        //{
        //    Name = "LG G7 ThinQ EndofCourse",
        //    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //    ImageFile = "product-6.png",
        //    Price = 240.00M,
        //    Category = "Home Kitchen"
        //}           

        //};

        #endregion
    }
}
