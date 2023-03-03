using Preparation.IRepos;
using Preparation.IService;
using Preparation.Models;
using System.Linq.Expressions;

namespace Preparation.Service
{
    public class ServicePersonnes : IServicePersonnes
    {
        IReposPersonnes _isp;
        public ServicePersonnes(IReposPersonnes isp) { _isp = isp; }
        public void Create(Personnes entity)
        {
            _isp.Create(entity);
        }

        public void Delete(Personnes entity)
        {
            _isp.Delete(entity);
        }

        public IQueryable<Personnes> FindAll()
        {
           return _isp.FindAll();
        }

        public IQueryable<Personnes> FindByCondition(Expression<Func<Personnes, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Personnes entity)
        {
            _isp.Update(entity);
        }
    }
}
