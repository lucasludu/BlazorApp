using BlazorAppVisualStudio.Models;

namespace BlazorAppVisualStudio.Services.Interfaces
{
    public interface ICategoryServices
    {
        Task<List<Category>?> Get();
    }
}
