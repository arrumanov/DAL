using Garden.Core.Entities;
using System.Linq;

namespace Garden.Core.DAL.Sort
{
    public interface ISort<TEntity> : ISortBase where TEntity : Entity
    {
        IQueryable<TEntity> AcceptQuery(IQueryable<TEntity> query);
    }
}
