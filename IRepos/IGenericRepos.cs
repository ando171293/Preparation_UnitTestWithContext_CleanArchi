using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Preparation.IRepos
{
    public interface IGenericRepos<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
