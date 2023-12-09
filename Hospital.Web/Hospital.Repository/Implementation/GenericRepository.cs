using Hospital.Repository.Repository;
using Hospital.Web;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Implementation
{
    public class GenericRepository<T> : IDisposable,IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbset;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbset = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public async Task<T> AddByAsync(T entity)
        {
            dbset.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }
            dbset.Remove(entity);
        }

        async Task<T> IGenericRepository<T>.DeleteByAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
            }
            dbset.Remove(entity);
            return entity;
        }
        private bool _disposed = false;

      

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderby,string includeProperties = "")
        {
            //string includeProperties = "";
            IQueryable<T> query = dbset;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeproperty in includeProperties.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
            {
                query= query.Include(includeproperty);
            }
            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            else
            {
                return query.ToList();
            }
            
        }

        public T GetById(object d)
        {
            return dbset.Find(d);
        }

        public async Task<T> GetByIdAsync(object d)
        {
            return await dbset.FindAsync(d);
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> UpdateByAsync(T entity)
        {
            dbset.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Dispose(bool isdisposing)
        {
            if (!this._disposed)
            {
                if (isdisposing)
                {
                    _context.Dispose();
                }

            }
            _disposed = true;
        }

        public IEnumerable<T> GetAll(string includeProperties = "")
        {

            IQueryable<T> query = dbset;
            foreach (var includeproperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeproperty);
            }
            return query.ToList();
        }

    
    }
}
