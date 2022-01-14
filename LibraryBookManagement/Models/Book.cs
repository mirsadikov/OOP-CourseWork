using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookManagement.Models
{
    public partial class Book : BaseEntity
    {
        public int YearPublished { get; set; }
        public string Category { get; set; }
        public string ISBN { get; set; }
        public BookStatus Status { get; set; }
    }

    public enum BookStatus
    {
        Reserved = 0,
        InLoan = 1,
        Available = 2
    }
}
