using Preparation.IRepos;
using Preparation.Models;
using System.Linq.Expressions;

namespace Preparation.IService
{
    public interface IServiceParents 
    {
        IQueryable<Parents> FindAll();
        IQueryable<Parents> FindByCondition(Expression<Func<Parents, bool>> expression);
        void Create(Parents entity);
        void Update(Parents entity);
        void Delete(Parents entity);
        void MockParents();
        void ExportParentsToXml();
        List<Parents> GetDataXMl();
    }
}
