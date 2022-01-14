using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookManagement.Models
{
    public partial class Loan : BaseEntity
    {
        public User Borrower { get; set; }
        public Book BorrowedBook { get; set; }
        public DateTime DateTaken { get; set; }
        public int Duration { get; set; }
        public bool IsReturned { get; set; }
    }
}
