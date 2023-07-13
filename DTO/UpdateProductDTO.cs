using System.ComponentModel.DataAnnotations;

namespace mli_microNetCore_StoredProcedure.DTO
{
    public class UpdateProductDTO
    {   
            [Required]
            public string Name { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            [Range(10, 2500, ErrorMessage = "Value must be higher than 10 and lower than 2500")]
            public int Price { get; set; }
            [Required]
            public string SKU { get; init; }
        
    }
}
