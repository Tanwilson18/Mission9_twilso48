using Microsoft.AspNetCore.Mvc;
using Mission9_twilso48.Models;
using Mission9_twilso48.Models.ViewModels;
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
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    totalNumTitles = repo.Books.Count(),
                    booksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
