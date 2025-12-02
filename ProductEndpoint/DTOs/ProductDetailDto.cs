namespace ProductEndpoint.DTOs
{
    public class ProductDetailDto
    {
        public BrandDto Brand { get; set; }
        public ProductTypeDto Type { get; set; }
        public List<ProductDto> Products { get; set; }
        public string? Description { get; set; }
    }
}