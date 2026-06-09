using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Question2.Controllers
{
    public class OrdersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:xxxx/api/ordersapi/buchanan";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    ViewBag.Orders = data;
                }
            }

            return View();
        }
    }
}