using Microsoft.AspNetCore.Mvc;
using SatinAlmaStokYonetim.Models;
using SatinAlmaStokYonetim.Web.Models;
using System.Text.Json;

namespace SatinAlmaStokYonetim.Web.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> GetAllCategory()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5208");

            string uri = $"{client.BaseAddress}api/categories/getCategories";

            var httpResponseMessage = await client.GetAsync(uri);
            
            var contentData = await httpResponseMessage.Content.ReadAsStringAsync();

            var jsonData = JsonSerializer.Deserialize<ResponseBody<List<CategoryItem>>>(contentData,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Json(jsonData!.data);
        }

    }
}
