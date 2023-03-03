using Preparation.IRepos;
using Preparation.Models;
using System.Linq.Expressions;

namespace Preparation.Repos
{
    public class ReposParents: IReposParents
    {
        public readonly PreparationContext _pc;
        public ReposParents(PreparationContext pc) { _pc = pc; }
        
        public void Create(Parents entity)
        {
            _pc.Parents.Add(entity);    
            _pc.SaveChanges();
        }

        public void Delete(Parents entity)
        {
            _pc.Parents.Remove(entity); 
            _pc.SaveChanges();
        }

        public IQueryable<Parents> FindAll()
        {
           return _pc.Parents;
        }

        public IQueryable<Parents> FindByCondition(Expression<Func<Parents, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Parents entity)
        {
            _pc.Parents.Update(entity);
            _pc.SaveChanges();  
        }
    }
}
