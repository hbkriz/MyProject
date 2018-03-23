using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProjectOData.Models;

namespace MyProjectOData.Business
{
    public class ProductService
    {
        public List<Product> Products
        {
            get { return p_products; }
        }

        public Product Find(int id)
        {
            return Products.Where(m => m.Id == id).FirstOrDefault();
        }
        
        private static List<Product> p_products = new Product[]
        {
            new Product { Id = 1, Name  = "Apple"},
            new Product { Id = 2, Name="Google" }
        }.ToList();

        private object _lock = new object();
    }
}