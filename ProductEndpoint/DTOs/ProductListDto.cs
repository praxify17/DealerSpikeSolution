namespace ProductEndpoint.DTOs
{
    public class ProductListDto
    {
        public BrandDto Brand { get; set; }
        public ProductTypeDto Type { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}