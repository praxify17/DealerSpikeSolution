using Microsoft.AspNetCore.Mvc;
using ProductEndpoint.Data;

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
	}
}
