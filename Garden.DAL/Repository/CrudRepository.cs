using System;
using System.Collections.Generic;
using System.Linq;
using Garden.Core.DAL;
using Garden.Core.DAL.Fetch;
using Garden.Core.DAL.Repository;
using Garden.Core.DAL.Sort;
using Garden.Core.DAL.Specification;
using Garden.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Garden.DAL.Repository
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : Entity
    {
        protected StorageContext storageContext;
        protected DbSet<TEntity> dbSet;

        public void SetStorageContext(IStorageContext storageContext)
        {
            this.storageContext = storageContext as StorageContext;
            this.dbSet = this.storageContext.Set<TEntity>();
        }

        protected IQueryable<TEntity> GetQuery(ISpecification<TEntity> specification = null, IFetch<TEntity> fetch = null, ISort<TEntity> sort = null)
        {
            var query = dbSet.AsQueryable();

            if (specification != null)
                query = query.Where(specification.IsSatisfiedBy());
            if (sort != null)
                query = sort.AcceptQuery(query);
            if (fetch != null)
                query = fetch.AcceptQuery(query);
            return query;
        }

        protected IQueryable<TEntity> GetPagedQuery(ISpecification<TEntity> specification = null, IFetch<TEntity> fetch = null, ISort<TEntity> sort = null, int page = 1, int pageSize = 25)
        {

            var query = GetQuery(specification, fetch, sort);

            if (page < 1)
                page = 1;
            if (pageSize < 1 || pageSize > 1000)
                pageSize = 100;
            var all = query.Skip((page - 1) * pageSize).Take(pageSize);
            return all;
        }

        #region Read
        public IEnumerable<TEntity> Find(ISpecification<TEntity> specification = null, IFetch<TEntity> fetch = null, ISort<TEntity> sort = null)
        {
            return GetQuery(specification, fetch, sort).ToList();
        }

        public IEnumerable<TEntity> FindWithPaging(ISpecification<TEntity> specification = null, IFetch<TEntity> fetch = null, ISort<TEntity> sort = null, int page = 1, int pageSize = 25)
        {
            return GetPagedQuery(specification, fetch, sort, page, pageSize).ToList();
        }

        public int Count(ISpecification<TEntity> specification = null)
        {
            return GetQuery(specification).Count();
        }

        public TEntity Read(ISpecification<TEntity> specification, IFetch<TEntity> fetch = null)
        {
            return GetQuery(specification, fetch).FirstOrDefault();
        }
        #endregion

        #region Create/Update/Delete
        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Create(List<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(ISpecification<TEntity> specification)
        {
            foreach (var entity in Find(specification))
            {
                Delete(entity);
            }
        }

        public void Update(TEntity entity)
        {
            storageContext.Entry<TEntity>(entity).State = EntityState.Modified;
            //DataContext.Update(entity);
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                storageContext.SaveChanges();
            }
            catch (Exception dbEx)
            {


                throw;
            }
        }

        public void Update(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }
        #endregion
    }
}
