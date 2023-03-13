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

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }


        // constructor 
        public BuyModel (IBookstoreRepo temp, Basket bask)
        {
            repo = temp;
            basket = bask;
        }

        public void OnGet(string returnurl)
        {
            ReturnUrl = returnurl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnurl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            //new instance
            basket.AddItem(b, 1);


            return RedirectToPage(new { ReturnUrl = returnurl });
        }
        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == BookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
 