using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twilso48.Models.ViewModels
{
    public class PageInfo
    {
        public int totalNumTitles {get; set; }
        public int booksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // figure out number of pages
        public int TotalPages =>  (int) Math.Ceiling((double) totalNumTitles / booksPerPage);
  

    }
}
