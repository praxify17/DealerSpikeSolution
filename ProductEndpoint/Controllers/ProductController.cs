using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductEndpoint.Data;
using ProductEndpoint.DTOs;
using AutoMapper;

namespace ProductEndpoint.Controllers
{
    [Route("api/v1/Sites/{siteId}/ProductKind/InStockUnit/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int siteId)
        {
            var products = await _context.Products
                .Where(p => p.SiteId == siteId)
                .Include(p => p.Brand)
                .Include(p => p.Type).ThenInclude(t => t.SubTypes)
                .Include(p => p.Media)
                .Include(p => p.Pricing)
                .Include(p => p.Location)
                .Include(p => p.Attributes)
                .ToListAsync();

            if (products == null || products.Count == 0)
                return NotFound();

            // Map entities to DTOs
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            // Use the first product for brand/type info (adjust as needed)
            var firstProduct = products.First();

            var response = new
            {
                brand = _mapper.Map<BrandDto>(firstProduct.Brand),
                type = _mapper.Map<ProductTypeDto>(firstProduct.Type),
                products = productDtos
            };

            return Ok(response);
        }
    }
}
