using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twilso48.Models
{
    public interface ICheckOutRepo
    {
        IQueryable<Checkout> Checkouts { get; }

        void SaveCheckout(Checkout checkoutTemp);
    }
}
