using CommentLog.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.DAL
{
    public interface IEFRepository<T> where T:BaseEntity
    {
        void Add(T entity);
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();
    }
}
