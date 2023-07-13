using Microsoft.AspNetCore.Mvc;
using mli_microNetCore_StoredProcedure.DTO;
using mli_microNetCore_StoredProcedure.Model;
using mli_microNetCore_StoredProcedure.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mli_microNetCore_StoredProcedure.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ImemoryProduct Repo;

        public ProductController(ImemoryProduct r)
        {
            this.Repo = r;
        }
        [HttpGet]
        public IEnumerable<ProductDTO> GetProducts()
        {
            var listProducts = Repo.getAllProducts();
            var products = new List<ProductDTO>();
            foreach (var item in listProducts)
            {
                var product = item.modelToDto(); 
                products.Add(product);
            }
            return products;
        }

        [HttpGet]
        [Route("SKU")]
        public ActionResult<ProductDTO> GetProduct (string sku)
        {
            var product = Repo.getProduct(sku).modelToDto();
            if (product is null)
            {
                return NotFound();
            }
            else
            {
                return product;
            } 
        }

        [HttpPost]
        public ActionResult<ProductDTO> CreateProduct(ProductDTO productDTO)
        {
            Product p = new Product()
            {
                Id = Repo.getAllProducts().Max(x => x.Id) + 1,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                SKU = productDTO.SKU,
                newDate = DateTime.Now,
            };   
            Repo.createProduct(p);
            return p.modelToDto();
        }
        [HttpPut] 
        public ActionResult<ProductDTO> updateProduct(string sku, UpdateProductDTO updateProduct) 
        {
            Product existProduct = Repo.getProduct(sku);
            if (existProduct is null)
            {
                return NotFound();
            }
            existProduct.Name = updateProduct.Name;
            existProduct.Description = updateProduct.Description;   
            existProduct.Price = updateProduct.Price;

            return existProduct.modelToDto();
        }
        [HttpDelete]
        public ActionResult<ProductDTO> deleteProduct(string sku)
        {
            Product product = Repo.getProduct(sku);
            if (product is null)
            {
                return NotFound();
            }
            else
            {
                Repo.deleteProduct(product);    
                return product.modelToDto();
            }
        }

    }
}
