using Preparation.IRepos;
using Preparation.IService;
using Preparation.Models;
using System.Linq.Expressions;

namespace Preparation.Service
{
    public class ServiceParents : IServiceParents
    {
        private readonly IReposParents _isp;
        public ServiceParents(IReposParents isp) { _isp = isp; }
        public void Create(Parents entity)
        {
            _isp.Create(entity);
        }

        public void Delete(Parents entity)
        {
            _isp.Delete(entity);
        }

        public IQueryable<Parents> FindAll()
        {
           return _isp.FindAll();
        }

        public IQueryable<Parents> FindByCondition(Expression<Func<Parents, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Parents entity)
        {
            _isp.Update(entity);
        }
    }
}
