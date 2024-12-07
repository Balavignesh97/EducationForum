using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationForum.DataAccess
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected EForumDBContext _applicationDbContext;

        public RepositoryBase(EForumDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Delete(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _applicationDbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _applicationDbContext.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _applicationDbContext.Set<T>().Where(predicate);
        }

        public void Update()
        {
            _applicationDbContext.SaveChanges();
        }

        public void UpdateEntity<T>(T entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }
    }
}
