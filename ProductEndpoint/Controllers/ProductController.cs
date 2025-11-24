using Microsoft.AspNetCore.Mvc;

namespace ProductEndpoint.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		[HttpGet]
		public IActionResult GetProducts()
		{
			var products = new List<object>
			{
				new { id = 1, name = "Laptop", price = 50000 },
				new { id = 2, name = "Phone", price = 20000 }
			};

			return Ok(products);
		}
	}
}
