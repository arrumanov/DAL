using Garden.Core.Entities;
using System.Linq;

namespace Garden.Core.DAL.Fetch
{
    public interface IFetch<TEntity> : IBaseFetch where TEntity : Entity
    {
        IQueryable<TEntity> AcceptQuery(IQueryable<TEntity> query);
    }
}
