using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCarAuction.Repository
{
    public class BaseEntity
    {
        public int Id
        {
            get;
            set;
        }
        public DateTime AddedDate
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }

    }
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetAsIQueryable();
        T Get(long id);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
