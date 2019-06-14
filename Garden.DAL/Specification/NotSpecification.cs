using Garden.Core.DAL.Specification;
using Garden.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Garden.DAL.Specification
{
    internal class NotSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : Entity
    {
        public NotSpecification(ISpecification<TEntity> specification)
            : base(Expression.Lambda<Func<TEntity, bool>>
                  (
                    Expression.Not(((BaseSpecification<TEntity>)specification).Exprs.Body),
                    ((BaseSpecification<TEntity>)specification).Exprs.Parameters
                  )
                  )
        {
        }
    }
}
