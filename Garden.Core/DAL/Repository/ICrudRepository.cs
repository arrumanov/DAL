using Garden.Core.DAL.Fetch;
using Garden.Core.DAL.Sort;
using Garden.Core.DAL.Specification;
using Garden.Core.Entities;
using System.Collections.Generic;

namespace Garden.Core.DAL.Repository
{
    public interface ICrudRepository<TEntity> : IBaseRepository where TEntity : Entity
    {
        IEnumerable<TEntity> Find(ISpecification<TEntity> specification = null, IFetch<TEntity> fetch = null, ISort<TEntity> sort = null);
        IEnumerable<TEntity> FindWithPaging(ISpecification<TEntity> specification = null, IFetch<TEntity> fetch = null, ISort<TEntity> sort = null, int page = 1, int pageSize = 25);
        TEntity Read(ISpecification<TEntity> specification, IFetch<TEntity> fetch = null);
        int Count(ISpecification<TEntity> specification = null);

        void Create(TEntity entity);
        void Create(List<TEntity> entities);
        void Update(TEntity entity);
        void Update(List<TEntity> entities);

        void Delete(TEntity entity);
        void Delete(ISpecification<TEntity> specification);
    }
}
