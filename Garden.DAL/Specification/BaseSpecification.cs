using Garden.Core.DAL.Specification;
using Garden.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Garden.DAL.Specification
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : Entity
    {
        public BaseSpecification(Expression<Func<TEntity, bool>> expr)
        {
            Exprs = expr;
        }

        public Expression<Func<TEntity, bool>> Exprs { get; }

        public ISpecification<TEntity> And(ISpecification<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        }

        public ISpecification<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }

        public ISpecification<TEntity> Or(ISpecification<TEntity> specification)
        {
            return new OrSpecification<TEntity>(this, specification);
        }

        public Expression<Func<TEntity, bool>> IsSatisfiedBy()
        {
            return Exprs;
        }
    }
}
