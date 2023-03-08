using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twilso48.Models;

namespace Mission9_twilso48.Components
{
    public class TypeViewComponent : ViewComponent
    {
        private IBookstoreRepo repo { get; set; }

        //construtor 
        public TypeViewComponent (IBookstoreRepo temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x=> x);

            return View(types);
        }
    }
}
