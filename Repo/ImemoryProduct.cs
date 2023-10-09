using mli_microNetCore_StoredProcedure.Model;
using System.Collections.Generic;

namespace mli_microNetCore_StoredProcedure.Repo
{
    public interface ImemoryProduct
    {
        public IEnumerable<Product> getAllProducts();
        public Product getProduct(string sku);
        public bool createProduct(Product p);
        void updateProduct(Product p);
        void deleteProduct(Product p);
    }
}
