using Webia.Data;

namespace Webia.Repositories
{
    public abstract  class AbstractRepos
    {
        protected readonly FlightContext context;

        public AbstractRepos(FlightContext context)
        {
                this.context = context; 
        }
    }
}
