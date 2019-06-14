using Garden.Core.DAL.Specification;
using Garden.Core.Entities;

namespace Garden.DAL.Specification
{
    internal class OrSpecification<TEntity> : BaseSpecification<TEntity> where TEntity : Entity
    {
        public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
            : base(((BaseSpecification<TEntity>)left).Exprs.OrElse(((BaseSpecification<TEntity>)right).Exprs))
        {
        }
    }
}
