using System;
using System.Numerics;

namespace mli_microNetCore_StoredProcedure.Model
{
    public class Product
    {
        public int Id { get; init; }
        public string Name{ get; set; }
        public string Description { get; set; } 
        public int Price { get; set; }
        public DateTime newDate { get; init; }
        public string SKU{ get; init; }
    }
}
