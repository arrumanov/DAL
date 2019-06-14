using Garden.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Garden.Core.DAL.Specification
{
    public interface ISpecification<TEntity> where TEntity : Entity
    {
        ISpecification<TEntity> And(ISpecification<TEntity> other);
        ISpecification<TEntity> Not();
        ISpecification<TEntity> Or(ISpecification<TEntity> other);
        Expression<Func<TEntity, bool>> IsSatisfiedBy();
    }
}
