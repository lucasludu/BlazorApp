using BlazorAppVisualStudio.Models;
using BlazorAppVisualStudio.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorAppVisualStudio.Services
{
    public class ProductServices : IProductServices
    {

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _optionsJson;

        public ProductServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._optionsJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Product>?> Get()
        {
            var response = await _httpClient.GetAsync("v1/products");
            var content = await response.Content.ReadAsStringAsync();
            
            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<Product>>(content, _optionsJson);
        }

        public async Task Add(Product product)
        {
            var response = await _httpClient.PostAsync("v1/products", JsonContent.Create(product));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task Delete(int productId)
        {
            var response = await _httpClient.DeleteAsync($"v1/products/{productId}");
            var content = await response.Content.ReadAsStringAsync();

            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

    }
}
