using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twilso48.Models
{
    public class EFCheckoutRepo : ICheckOutRepo
    {
        private BookstoreContext context;
        public EFCheckoutRepo(BookstoreContext temp)
        {
            context = temp;
        }
            public IQueryable<Checkout> Checkouts => context.Checkouts.Include(x => x.Lines).ThenInclude(x => x.Book );

        public void SaveCheckout(Checkout checkoutTemp)
        {
            context.AttachRange(checkoutTemp.Lines.Select(x => x.Book));

            if(checkoutTemp.CheckOutId == 0)
            {
                context.Checkouts.Add(checkoutTemp);
            }
            context.SaveChanges();
        }
    }
}
