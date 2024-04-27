using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using mvc.Repo;

namespace mvc.Controllers
{
    // [Route("[controller]")]
    public class BuyControllers : Controller
    {
        private readonly ILogger<BuyControllers> _logger;
        private readonly BuyRepository _buyRepository;

        public BuyControllers(ILogger<BuyControllers> logger, BuyRepository buyRepository)
        {
            _logger = logger;
            _buyRepository = buyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuyProduct(tblBuy buy)
        {
            Console.WriteLine(buy.c_quantity);   
            _buyRepository.buy(buy);
            return Json("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}