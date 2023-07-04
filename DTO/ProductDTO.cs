using System;

namespace mli_microNetCore_StoredProcedure.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string SKU { get; init; }
    }
}
