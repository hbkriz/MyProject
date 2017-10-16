using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectApi.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;
        private IDbSet<T> Entities => _context.Set<T>();

        public Repository(Context context)
        {
            _context = context;
        }
        
        public T Add(T t)
        {
            Entities.Add(t);
            return t;
        }

        public void Delete(T t)
        {
            if (_context.Entry(t).State == EntityState.Detached)
            {
                Entities.Attach(t);
            }
            Entities.Remove(t);
        }

        public T Get(Expression<Func<T, bool>> match)
        {
            return Entities.SingleOrDefault(match);
        }

        public IQueryable<T> GetAll()
        {
            return Entities;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> match)
        {
            var matches = Entities.Where(match);
            return matches;
        }

        public T Update(T t)
        {
            Entities.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            return t;
        }

    }
}