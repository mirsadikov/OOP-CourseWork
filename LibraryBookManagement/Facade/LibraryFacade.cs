    using LibraryBookManagement.Context;
using LibraryBookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBookManagement.Repository;
using LibraryBookManagement.Services;

namespace LibraryBookManagement.Facade
{
    public class LibraryFacade
    {
        private readonly MyDbContext context;
        public LibraryFacade(MyDbContext context) 
        {
            this.context = context;
        }

        public IEnumerable<T> GetAll<T>() where T : BaseEntity
        {
            return new Repository<T>(context).GetAll();
        }

        public  void  Insert<T>(T entity) where T : BaseEntity
        {
            new Repository<T>(context).Insert(entity);
        }

        public T Get<T>(int id) where T : BaseEntity
        {
            return new Repository<T>(context).Get(id);
        }

        public IEnumerable<T> Search<T>(string query) where T: BaseEntity
        {
            return new Utils<T>(context).Search(query);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            new Repository<T>(context).Update(entity);
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            new Repository<T>(context).Delete(entity);
        }

        public void EndLoan(long id)
        {
            new LoanManager(context).EndLoan(id);
        }

        public void LoanBook(Loan l)
        {
            new LoanManager(context).LoanBook(l);
        }
    }
}
