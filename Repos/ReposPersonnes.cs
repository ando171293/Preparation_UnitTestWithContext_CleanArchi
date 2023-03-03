using Preparation.IRepos;
using Preparation.Models;

namespace Preparation.Repos
{
    public class ReposPersonnes : GenericRepos<Personnes>, IReposPersonnes
    {
        public ReposPersonnes(PreparationContext pc) : base(pc) { }
    }
}
