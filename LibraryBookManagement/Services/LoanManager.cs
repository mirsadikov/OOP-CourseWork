using LibraryBookManagement.Context;
using LibraryBookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookManagement.Services
{
    public class LoanManager
    {
        private DbSet<Loan> entities;
        private readonly MyDbContext _context;

        public LoanManager(MyDbContext context)
        {
            _context = context;
            entities = context.Set<Loan>();
        }

        public void LoanBook(Loan l)
        {
            entities.Add(l);
            _context.SaveChanges();
        }

        public void EndLoan(long LoanId)
        {
            entities.Remove(entities.SingleOrDefault(s => s.Id == LoanId));
            _context.SaveChanges();
        }
    }
}
