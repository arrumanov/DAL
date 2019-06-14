using Garden.Core.DAL.Specification;
using Garden.Core.Entities;
using System;
using System.Linq.Expressions;

namespace Garden.DAL.Specification
{
    public abstract class BaseBuilder<TEntity> : ISpecificationBuilder<TEntity> where TEntity : Entity
    {
        private BaseSpecification<TEntity> _specification;
        private Func<ISpecification<TEntity>, ISpecification<TEntity>> _nextMethod;

        public IExpression<TEntity, ISpecificationBuilder<TEntity>> Add(Expression<Func<TEntity, bool>> expr)
        {
            if (_specification == null)
            {
                _specification = new BaseSpecification<TEntity>(expr);
            }
            else
            {
                _specification = (BaseSpecification<TEntity>)_nextMethod(new BaseSpecification<TEntity>(expr));
            }

            return CreateExpression(this);
        }


        public abstract IExpression<TEntity, ISpecificationBuilder<TEntity>> CreateExpression(BaseBuilder<TEntity> abstractBuilder);
        public class MyExpression<TEntity, TBaseBuilder> :
            IExpression<TEntity, TBaseBuilder>
            where TEntity : Entity
            where TBaseBuilder : ISpecificationBuilder<TEntity>
        {
            private readonly ISpecificationBuilder<TEntity> _builder;
            public MyExpression(ISpecificationBuilder<TEntity> builder)
            {
                _builder = builder;
            }

            public TBaseBuilder And()
            {
                ((BaseBuilder<TEntity>)_builder)._nextMethod = ((BaseBuilder<TEntity>)_builder)._specification.And;
                return (TBaseBuilder)_builder;
            }

            public TBaseBuilder Or()
            {
                ((BaseBuilder<TEntity>)_builder)._nextMethod = ((BaseBuilder<TEntity>)_builder)._specification.Or;
                return (TBaseBuilder)_builder;
            }

            public IExpression<TEntity, TBaseBuilder> Not()
            {
                ((BaseBuilder<TEntity>)_builder)._specification =
                   (BaseSpecification<TEntity>)((BaseBuilder<TEntity>)_builder)._specification.Not();
                return this;
            }

            public ISpecification<TEntity> Build()
            {
                return ((BaseBuilder<TEntity>)_builder)._specification;
            }


        }
    }
}
