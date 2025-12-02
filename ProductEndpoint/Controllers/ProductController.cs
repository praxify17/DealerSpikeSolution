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

        [HttpGet("{productId}/details")]
        public async Task<IActionResult> GetAllDetails(int siteId, int productId)
        {
            var product = await _context.Products
                .Where(p => p.SiteId == siteId && p.Id == productId)
                .Include(p => p.Brand)
                .Include(p => p.Type).ThenInclude(t => t.SubTypes)
                .Include(p => p.Media)
                .Include(p => p.Pricing)
                .Include(p => p.Location)
                .Include(p => p.Attributes)
                .FirstOrDefaultAsync();

            if (product == null)
                return NotFound();

            var productDto = _mapper.Map<ProductDto>(product);
            var brandDto = _mapper.Map<BrandDto>(product.Brand);
            var typeDto = _mapper.Map<ProductTypeDto>(product.Type);

            var response = new ProductDetailDto
            {
                Brand = brandDto,
                Type = typeDto,
                Products = new List<ProductDto> { productDto },
                Description = "<div id=\"productDetailDescription\"><div class=\"productDescription\"><div class=\"primaryProductDescription\"><p>The Perfect First Time Companion\r<br><br>\r<br><br>Packed with plenty of power in a mid-size ATV, the Alterra 300 is perfect for long days out on the trail. Versatile and lightweight, this vehicle is built for a first-timer looking to keep up with the seasoned riders.</p></div><ul class=\"primaryProductFeatures\">\r</ul> <div id=\"itemGroup\" class=\"productItemGroup\"><div class=\"productItemGroupName\">Key Features</div><ul class=\"itemGroupFeatures\"><li id=\"102379623\" class=\"productFeature\">300 Class Engine: The Alterra 300 offers a relentless, liquid-cooled 270cc gas engine that keeps a steady temperature during long jobs and all-day adventures, making this the perfect mid-size ATV for work or play.</li><li id=\"102379624\" class=\"productFeature\">Double A-arm Front And Swing-arm Style Rear Suspension: Don't just deal with bumps in the road - conquer them with five inches of front and rear travel.</li><li id=\"102379625\" class=\"productFeature\">Front Racks, Rear Racks, & Towing: Don't let this mid-sized ATV fool you - with the Alterra 300, work might not seem like much of a chore. Pile on the weight with 50 lbs front and 100 lbs rear impact-resistant composite racks, along with 500 lbs of towing capacity.</li><li id=\"102379626\" class=\"productFeature\">Automatic Cvt Transmission: Equipped with simple, ready-to-ride acceleration, beginners and seasoned off roaders alike will love the feel of the Alterra 300 ATV.</li><li id=\"102379627\" class=\"productFeature\">Dual Halogen Headlights And Taillights: After a full day of riding, you won't want the fun to end as the sun goes down. With dual halogen headlights and taillights, it might not have to. Enjoy the increased visibility and safety offered by the Alterra 300.</li><li id=\"102379628\" class=\"productFeature\">Low Maintenance Shaft-driven Solid Rear Axle: With the Alterra 300, you'll even be prepared for tight turns as you take on the trails with improved traction, all with little upkeep.</li><li id=\"102379629\" class=\"productFeature\">12-month Warranty: With a year of rock-solid coverage protecting your ATV, you can have peace of mind on and off the trail.</li></ul><div class=\"productItemGroupName\">Engine & Drivetrain</div><ul class=\"itemGroupFeatures\"><li id=\"102379630\" class=\"productFeature\">Engine Type: Liquid-Cooled, Single Cylinder</li><li id=\"102379631\" class=\"productFeature\">Displacement: 270cc</li><li id=\"102379632\" class=\"productFeature\">Drive Train: Cvt</li><li id=\"102379633\" class=\"productFeature\">Drive System: 2wd Shaft Drive</li><li id=\"102379634\" class=\"productFeature\">Fuel System: Carburetor</li><li id=\"102379635\" class=\"productFeature\">Gear Selection: H/L/N/R</li><li id=\"102379636\" class=\"productFeature\">Rear Differential: Locked</li></ul><div class=\"productItemGroupName\">Steering & Suspension</div><ul class=\"itemGroupFeatures\"><li id=\"102379637\" class=\"productFeature\">Steering: Standard</li><li id=\"102379638\" class=\"productFeature\">Front Suspension: Double A-Arm with 5 in. (12.7 cm) Travel</li><li id=\"102379639\" class=\"productFeature\">Rear Suspension: Double A-Arm with 5 in. (12.7 cm) Travel</li><li id=\"102379640\" class=\"productFeature\">Brake System: Dual Front Hydraulic Disc, Single Rear Hydraulic Disc</li><li id=\"102379641\" class=\"productFeature\">ft. Brake: ft. Operated Rear Brake</li><li id=\"102379642\" class=\"productFeature\">Parking Brake: Lockable Hand Lever</li><li id=\"102379643\" class=\"productFeature\">Front Tires: 22 x 7 - 10</li><li id=\"102379644\" class=\"productFeature\">Rear Tires: 22 x 10 - 10</li><li id=\"102379645\" class=\"productFeature\">Wheels: Steel</li></ul><div class=\"productItemGroupName\">Performance</div><ul class=\"itemGroupFeatures\"><li id=\"102379646\" class=\"productFeature\">Total Capacity: 400 lb. (181.5 kg)</li><li id=\"102379647\" class=\"productFeature\">Front Rack: 50 lb. (23 kg)</li><li id=\"102379648\" class=\"productFeature\">Rear Rack: 100 lb. (45.5 kg)</li><li id=\"102379649\" class=\"productFeature\">Towing Capacity: 500 lb. (227 kg)</li></ul><div class=\"productItemGroupName\">Dimensions</div><ul class=\"itemGroupFeatures\"><li id=\"102379650\" class=\"productFeature\">Overall Length: 72.6 in. (184.5 cm)</li><li id=\"102379651\" class=\"productFeature\">Overall Width: 41.3 in. (105 cm)</li><li id=\"102379652\" class=\"productFeature\">Overall Height: 45.8 in. (116 cm)</li><li id=\"102379653\" class=\"productFeature\">Overall Weight (Dry): 517 lb. (234.5 kg)</li><li id=\"102379654\" class=\"productFeature\">Wheel Base: 46 in. (117 cm)</li><li id=\"102379655\" class=\"productFeature\">Ground Clearance: 6.5 in. (16.5 cm)</li><li id=\"102379656\" class=\"productFeature\">Fuel Capacity: 3.2 gal. (12 L)</li><li id=\"102379657\" class=\"productFeature\">Hitch: Hitch Plate</li></ul><div class=\"productItemGroupName\">Color Options</div><ul class=\"itemGroupFeatures\"><li id=\"102379658\" class=\"productFeature\">Standard Colors: Coyote Tan</li></ul><div class=\"productItemGroupName\">Features</div><ul class=\"itemGroupFeatures\"><li id=\"102379659\" class=\"productFeature\">Standard Instrumentation: Digital Multifunction Guage</li><li id=\"102379660\" class=\"productFeature\">Lighting: Dual Halogen Headlights and Dual Halogen Brakelight/Taillight</li><li id=\"102379661\" class=\"productFeature\">Start Method: Electric Start</li></ul><div class=\"productItemGroupName\">Warranty</div><ul class=\"itemGroupFeatures\"><li id=\"102379662\" class=\"productFeature\">Warranty: 12 Month</li></ul></div></div></div>"
			};

            return Ok(response);
        }
    }
}
