using BlazorAppVisualStudio.Models;
using BlazorAppVisualStudio.Services.Interfaces;
using System.Text.Json;

namespace BlazorAppVisualStudio.Services
{
    public class CategoryServices : ICategoryServices
    {

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _optionsJson;

        public CategoryServices(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._optionsJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; ;
        }

        public async Task<List<Category>?> Get()
        {
            var response = await _httpClient.GetAsync("v1/categories");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<Category>>(content, _optionsJson);
        }

    }
}
