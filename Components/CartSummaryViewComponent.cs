using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twilso48.Models;
using Microsoft.AspNetCore.Mvc;


namespace Mission9_twilso48.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket cart;
        public CartSummaryViewComponent(Basket cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
