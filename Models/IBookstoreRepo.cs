using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_twilso48.Models
{
    // Make inerface not class
    public interface IBookstoreRepo
    {
        IQueryable<Books> Books { get; }
    }
}
