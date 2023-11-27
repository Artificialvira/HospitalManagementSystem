using Hospital.Repository.Interfaces;
using Hospital.Repository.Repository;
using Hospital.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        private bool Disposed=false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
        }


        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> repository = new GenericRepository<T>(_context);
            return repository;
        }

        public void save()
        {
            _context.SaveChanges(); 
        }
    }
}
