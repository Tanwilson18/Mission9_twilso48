using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twilso48.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckOutId { get; set; }

        [BindNever]

        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "PLease enter an address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "PLease enter a City")]

        public string City { get; set; }

        [Required(ErrorMessage = "PLease enter a State")]
        public string State { get; set; }

        [Required(ErrorMessage = "PLease enter a ZipCode")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "PLease enter a Country")]
        public string Country { get; set; }



    }
}
