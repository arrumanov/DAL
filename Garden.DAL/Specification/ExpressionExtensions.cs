using System;
using System.Linq.Expressions;

namespace Garden.DAL.Specification
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TEntity, bool>> AndAlso<TEntity>(this Expression<Func<TEntity, bool>> expr1, Expression<Func<TEntity, bool>> expr2)
        {
            ParameterExpression parameterExpression = expr1.Parameters[0];
            if (ReferenceEquals(parameterExpression, expr2.Parameters[0]))
                return Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(expr1.Body, expr2.Body), parameterExpression);
            return Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(expr1.Body, Expression.Invoke(expr2, parameterExpression)), parameterExpression);
        }

        public static Expression<Func<TEntity, bool>> OrElse<TEntity>(this Expression<Func<TEntity, bool>> expr1, Expression<Func<TEntity, bool>> expr2)
        {
            ParameterExpression parameterExpression = expr1.Parameters[0];
            if (ReferenceEquals(parameterExpression, expr2.Parameters[0]))
                return Expression.Lambda<Func<TEntity, bool>>(Expression.OrElse(expr1.Body, expr2.Body), parameterExpression);
            return Expression.Lambda<Func<TEntity, bool>>(Expression.OrElse(expr1.Body, Expression.Invoke(expr2, parameterExpression)), parameterExpression);
        }
    }
}
