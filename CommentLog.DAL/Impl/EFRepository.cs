using CommentLog.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.DAL
{
    public class EFRepository<T> : IEFRepository<T> where T : BaseEntity
    {
        private DbContext _context;
        private IDbSet<T> _dbset;
        public EFRepository(DbContext context)
        {
            this._context = context;
            _dbset = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbset.Where(predicate).AsQueryable();
            return query;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _dbset.AsQueryable();
            return query;
        }
    }
}
