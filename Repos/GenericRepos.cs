using Microsoft.EntityFrameworkCore;
using Preparation.IRepos;
using Preparation.Models;
using System.Linq.Expressions;

namespace Preparation.Repos
{
    public abstract class GenericRepos<T> : IGenericRepos<T> where T : class
    {
        PreparationContext _pc;
        public GenericRepos(PreparationContext pc)
        {
            _pc= pc;
        }
        public IQueryable<T> FindAll() => _pc.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>  _pc.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => _pc.Set<T>().Add(entity);
        public void Update(T entity) => _pc.Set<T>().Update(entity);
        public void Delete(T entity) => _pc.Set<T>().Remove(entity);
    }
}
