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
        
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            var blah = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum-1) * pageSize)
                .Take(pageSize);


            return View(blah);
        }
    }
}
