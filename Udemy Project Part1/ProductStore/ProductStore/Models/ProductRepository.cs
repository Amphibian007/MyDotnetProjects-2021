using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Models
{
    public class ProductRepository
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>
            {
                new Product
                {
                    ProductId=1,
                    Name="Mobile",
                    Price=(decimal)98.6
                },
                new Product
                {
                    ProductId=2,
                    Name="Book",
                    Price=(decimal)108.6
                },
                new Product
                {
                    ProductId=3,
                    Name="Bat",
                    Price=(decimal)500.6
                },
                new Product
                {
                    ProductId=4,
                    Name="Ball",
                    Price=(decimal)30.6
                },
                new Product
                {
                    ProductId=5,
                    Name="Diary",
                    Price=(decimal)120.6
                },
                  new Product
                {
                    ProductId=6,
                    Name="Product of the month",
                    Price=(decimal)100.6
                }
            };
            return allProducts;
        }
        public static Product GetSingleProduct(string slug)
        {
            var products = ProductRepository.GetAllProducts();
            foreach(var item in products)
            {
                if (item.Slug == slug)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
