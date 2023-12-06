using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Repository
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T,bool>> filter,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderby,
            string includeParameters = "");
        T GetById(object d);
        Task<T> GetByIdAsync(object d);
        void Add(T entity);
        Task<T> AddByAsync(T entity);
        void Update(T entity);
        Task<T> UpdateByAsync(T entity);
        void Delete(T entity);
        Task<T> DeleteByAsync(T entity);
        public IEnumerable<T> GetAll();

    }
}
