using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mli_microNetCore_StoredProcedure.DTO;
using mli_microNetCore_StoredProcedure.Model;
using mli_microNetCore_StoredProcedure.Repo;
using System.Collections;
using System.Collections.Generic;

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

    }
}
