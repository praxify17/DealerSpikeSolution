using Microsoft.AspNetCore.Mvc;
using ProductEndpoint.Data;
using ProductEndpoint.Model;

namespace ProductEndpoint.Controllers
{
	public class ProductController : Controller
	{
		private readonly ProductDbContext _context;

		public ProductController(ProductDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var products = _context.Products.ToList();
			return View(products);
		}

		[HttpGet("api/products")]
		public IActionResult GetProducts()
		{
			return Ok(_context.Products.ToList());
		}

		[HttpPost("api/products")]
		public IActionResult CreateProduct([FromBody] Product model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_context.Products.Add(model);
			_context.SaveChanges();

			return Ok(model);
		}
	}
}
