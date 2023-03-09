using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9_twilso48.Infrastructure;
using Mission9_twilso48.Models;

namespace Mission9_twilso48.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepo repo { get; set; }

        // constructor 
        public BuyModel (IBookstoreRepo temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnurl)
        {
            ReturnUrl = returnurl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId, string returnurl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            //new instance
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);


            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnurl });
        }
    }
}
