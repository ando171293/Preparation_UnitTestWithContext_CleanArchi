using Preparation.Models;
using System.Linq.Expressions;

namespace Preparation.IRepos
{
    public interface IReposParents
    {
        IQueryable<Parents> FindAll();
        IQueryable<Parents> FindByCondition(Expression<Func<Parents, bool>> expression);
        void Create(Parents entity);
        void Update(Parents entity);
        void Delete(Parents entity);
    }
}
