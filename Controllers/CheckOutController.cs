using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twilso48.Models; 

namespace Mission9_twilso48.Controllers
{
    public class CheckOutController : Controller
    {
        private ICheckOutRepo repo { get; set; }
        private Basket basket { get; set; }

        public CheckOutController(ICheckOutRepo temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }
        [HttpPost]
        public IActionResult Checkout(Checkout checkoutTemp)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, you cart is empty buddy");
            }
            if (ModelState.IsValid)
            {
                checkoutTemp.Lines = basket.Items.ToArray();
                repo.SaveCheckout(checkoutTemp);
                basket.ClearBasket();

                return RedirectToPage ("/CheckoutCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
