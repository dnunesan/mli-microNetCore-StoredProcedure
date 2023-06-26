using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly memoryProduct Repo;

        public ProductController()
        {
            this.Repo = new memoryProduct();
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var listProducts = Repo.getAllProducts();
            return listProducts;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Product> GetProduct (int Id)
        {
            var product = Repo.getProduct(Id);
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
