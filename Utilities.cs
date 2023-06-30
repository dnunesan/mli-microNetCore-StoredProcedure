using mli_microNetCore_StoredProcedure.DTO;
using mli_microNetCore_StoredProcedure.Model;

namespace mli_microNetCore_StoredProcedure
{
    public static class Utilities
    {
        public static ProductDTO modelToDto(this Product P) 
        {
            if (P != null)
            {
                return new ProductDTO()
                {
                    Name = P.Name,
                    Description = P.Description,
                    Price = P.Price,
                    SKU = P.SKU,
                };
            }else { return null; }  
        }
    }
}
