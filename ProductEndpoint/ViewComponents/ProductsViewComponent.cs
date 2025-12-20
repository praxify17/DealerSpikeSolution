using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductEndpoint.DTOs;

namespace ProductEndpoint.ViewComponents
{
    public sealed class ProductsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Uses internal endpoints similarly to the external data model flow.
        // When productId is provided, fetch product details; otherwise fetch products for the site.
        // productKind defaults to InStockUnit to match inventory views.
        public async Task<IViewComponentResult> InvokeAsync(int siteId, int? productId = null, string productKind = "InStockUnit")
        {
            var client = _httpClientFactory.CreateClient("ProductsApi");

            HttpResponseMessage response;
            if (productId.HasValue && productId.Value > 0)
            {
                // Details endpoint: api/v1/Sites/{siteId}/ProductKind/{productKind}/Products/{productId}/details
                var detailsUrl = $"api/v1/Sites/{siteId}/ProductKind/{productKind}/Products/{productId.Value}/details";
                response = await client.GetAsync(detailsUrl);
            }
            else
            {
                // List endpoint: api/v1/Sites/{siteId}/ProductKind/{productKind}/Products
                var listUrl = $"api/v1/Sites/{siteId}/ProductKind/{productKind}/Products";
                response = await client.GetAsync(listUrl);
            }

            if (!response.IsSuccessStatusCode)
            {
                return View("Error", $"Failed to fetch products. StatusCode: {(int)response.StatusCode}");
            }

            // Map both list and details responses into ProductsResponseDto, since the Default view expects it.
            var content = await response.Content.ReadFromJsonAsync<ProductsResponseDto>();
            return View(content);
        }
    }
}
