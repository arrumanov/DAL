using Garden.Core.DAL.Specification;
using Garden.Core.Entities;

namespace Garden.DAL.Specification
{
    internal class AndSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : Entity
    {
        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
            : base(((BaseSpecification<TEntity>)left).Exprs.AndAlso(((BaseSpecification<TEntity>)right).Exprs))
        {
        }
    }
}
