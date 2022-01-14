using LibraryBookManagement.Context;
using LibraryBookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookManagement.Facade
{
    public class Utils<T> where T : BaseEntity
    {

        private DbSet<T> entities;
        public Utils(MyDbContext context) 
        {
            entities = context.Set<T>();
        }
        public IEnumerable<T> Search(string query)
        {
            return entities.AsEnumerable().Where(q => q.Name.ToLower().Contains(query.ToLower()));

        }
    }
}
