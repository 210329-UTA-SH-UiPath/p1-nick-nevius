using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaBoxClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaBoxClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44330/api/Order");
            var response = client.GetAsync("");
            response.Wait();

            var str = response.Result.Content.ReadAsStringAsync();
            str.Wait();
            System.Console.WriteLine(str.Result);
            //var read = response.Result.Content.ReadAsAsync<PizzaBox.Domain.Models.Order[]>();
            //read.Wait();

            return View(str.Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
