using Garden.Core.Entities;

namespace Garden.Core.DAL.Specification
{
    public interface IExpression<TEntity, out TBaseBuilder>
        where TEntity : Entity
        where TBaseBuilder : ISpecificationBuilder<TEntity>
    {
        TBaseBuilder And();
        TBaseBuilder Or();

        IExpression<TEntity, TBaseBuilder> Not();


        ISpecification<TEntity> Build();
    }
}
