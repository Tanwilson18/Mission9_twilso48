using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twilso48.Models
{
    public class EFBookstoreRepo : IBookstoreRepo
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRepo (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Books> Books => context.Books;
    }
}
