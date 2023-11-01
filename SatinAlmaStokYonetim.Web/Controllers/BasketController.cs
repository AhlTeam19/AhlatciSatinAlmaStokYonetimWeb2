using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using SatinAlmaStokYonetim.Web.Models;

namespace SatinAlmaStokYonetim.Web.Controllers
{
    public class BasketController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BasketModel model)
        {

            var json = JsonSerializer.Serialize(model);

            using HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5208");

            string uri = $"{client.BaseAddress}baskets/insertBasket";

            var httpResponseMessage = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));

            return Json(new { IsSuccess = true });
        }
    }
}
