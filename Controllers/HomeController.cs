using Microsoft.AspNetCore.Mvc;
using Mission9_twilso48.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twilso48.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepo repo;

        public HomeController(IBookstoreRepo temp)
        {
            repo = temp;
        }
        
        public IActionResult Index()
        {
            var blah = repo.Books.ToList();

            return View(blah);
        }
    }
}
