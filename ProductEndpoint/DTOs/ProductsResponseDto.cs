using System.Collections.Generic;

namespace ProductEndpoint.DTOs
{
    public class ProductsResponseDto
    {
        public BrandDto Brand { get; set; }
        public ProductTypeDto Type { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
