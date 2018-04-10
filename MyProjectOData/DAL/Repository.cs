using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyProjectOData.DAL
{
    public class Repository : IRepository
    {
        private readonly IBaseContext _context;

        public Repository(IBaseContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> condition = null) where T : class
        {
            return condition != null ? _context.Set<T>().Where(condition) : _context.Set<T>();
        }
    }
}