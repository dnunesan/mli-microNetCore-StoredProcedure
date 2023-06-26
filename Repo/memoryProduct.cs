using mli_microNetCore_StoredProcedure.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mli_microNetCore_StoredProcedure.Repo
{
    public class memoryProduct
    {
        private readonly List<Product> products = new()
        {
            new Product {Id = 1,Name="Teclado",Description="Teclado membrana",Price=25,newDate=DateTime.Now},
            new Product {Id = 2,Name="Teclado gamer",Description="Teclado meacanico",Price=75,newDate=DateTime.Now},
            new Product {Id = 3,Name="Teclado ergonomico",Description="Teclado membrana",Price=175,newDate=DateTime.Now},
            new Product {Id = 4,Name="Teclado TKL",Description="Teclado mecanivo",Price=105,newDate=DateTime.Now}
        };

        public IEnumerable<Product> getAllProducts() 
        { 
            return products; 
        }
        
        public Product getProduct (int Id)
        {
            return products.Where(p=>p.Id==Id).SingleOrDefault();
        }

        }
}