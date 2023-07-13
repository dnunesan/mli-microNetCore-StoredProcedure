using mli_microNetCore_StoredProcedure.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mli_microNetCore_StoredProcedure.Repo
{
    public class memoryProduct: ImemoryProduct
    {
        private readonly List<Product> products = new()
        {
            new Product {Id = 1,Name="Teclado",Description="Teclado membrana",Price=25,newDate=DateTime.Now, SKU = "AA-001"},
            new Product {Id = 2,Name="Teclado gamer",Description="Teclado meacanico",Price=75,newDate=DateTime.Now,SKU="AA-002"},
            new Product {Id = 3,Name="Teclado ergonomico",Description="Teclado membrana",Price=175,newDate=DateTime.Now,SKU="AA-003"},
            new Product {Id = 4,Name="Teclado TKL",Description="Teclado mecanico",Price=105,newDate=DateTime.Now,SKU="AA-004"}
        };


        public IEnumerable<Product> getAllProducts() 
        { 
            return products; 
        }
        
        public Product getProduct (string sku)
        {
            return products.Where(p=>p.SKU==sku).SingleOrDefault();
        }
        public void createProduct(Product p)
        {
            products.Add(p);
        }

        public void updateProduct(Product p)
        {
            int a = products.FindIndex(ifExixsts=> ifExixsts.Id==p.Id);

            products[a]=p;
        }

        public void deleteProduct(Product p)
        {
            Product productToRemove = getProduct(p.SKU);
            
            products.Remove(productToRemove);
        }
    }
}