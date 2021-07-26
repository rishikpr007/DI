using DI.Filters;
using DI.Infrastructure;
using DI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepo _repo;

        public HomeController(ILogger<HomeController> logger, IProductRepo Repo)
        {
            _logger = logger;
            _repo = Repo;
        }

        public IActionResult Index()
        {
            var items = _repo.GetAll();

            return View(items);
        }
        [CatchError]
        public IActionResult Details( int id)
        {
            var items = _repo.GetByID(id);

#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id == null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                throw new Exception("Error Id cannot be null");
            else
                return View(items);                  
                       
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
