using Microsoft.AspNetCore.Mvc;
using SatinAlmaStokYonetim.Code;
using SatinAlmaStokYonetim.Models;
using System.Text;
using System.Text.Json;

namespace SatinAlmaVeStockMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AccountModel model)
        {

            using HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5208");

            string uri = $"{client.BaseAddress}login/getLogin?userName={model.userName}&userPassword={model.userPassword}";

            var json = JsonSerializer.Serialize(new { model.userName, model.userPassword });

            var httpResponse = await client.PostAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));

            var httpResponseMessage2 = await client.GetAsync($"{client.BaseAddress}authority/getAllAuthorities");

            var cd = await httpResponseMessage2.Content.ReadAsStringAsync();

            var js = JsonSerializer.Deserialize<ResponseBody<List<AuthorityItem>>>(cd,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var contentData = await httpResponse.Content.ReadAsStringAsync();

            var jsonData = JsonSerializer.Deserialize<ResponseBody<AccessTokenItem>>(contentData,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            if (jsonData.data.Token != null)
            {
                Repo.Session.Token = jsonData.data.Token;
                Repo.Session.Username = jsonData!.data.Claims[0];
                Repo.Session.Authority = jsonData.data.Claims[1];
                Repo.Session.UserId = jsonData.data.Claims[2].ToString();
                Repo.Session.CompanyId = jsonData.data.Claims[3].ToString();
                Repo.Session.DepartmentId = jsonData.data.Claims[4].ToString();
                Repo.Session.CompanyName = jsonData.data.Claims[5].ToString();
                Repo.Session.DepartmentName = jsonData.data.Claims[6].ToString();


                if (Repo.Session.Authority== "Admin")
                {
                    return Json(new { result = "Redirect", url = Url.Action("Home", "Admin") });
                }
                else if(Repo.Session.Authority == "Satın Alma" || Repo.Session.Authority == "Talep" || Repo.Session.Authority == "Muhasebe")
                {
                    return Json(new { result = "Redirect", url = Url.Action("Home", "Employee") });
                }
                else
                {
                    return Json(new { result = "Redirect", url = Url.Action("Login", "Account") });
                }
            }
            return Json(new { result = "Redirect", url = Url.Action("Login", "Account") });

        }

        public IActionResult Logout()
        {
            Repo.Session.Username = null;
            Repo.Session.Token = null;
            Repo.Session.Authority = null;
            Repo.Session.UserId = null;
            Repo.Session.Company = null;
            Repo.Session.CompanyId = null;

            return RedirectToAction("Login");
        }
    }
}
