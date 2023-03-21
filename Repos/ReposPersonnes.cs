using Preparation.IRepos;
using Preparation.Models;

namespace Preparation.Repos
{
    public class ReposPersonnes : GenericRepos<Personnes>, IReposPersonnes
    {
        public ReposPersonnes(Context pc) : base(pc) { }
    }
}
