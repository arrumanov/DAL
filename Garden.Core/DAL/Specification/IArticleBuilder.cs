using Garden.Core.Entities;
using Garden.Core.Enums;

namespace Garden.Core.DAL.Specification
{
    public interface IArticleBuilder : ISpecificationBuilder<Article>, IBaseSpecificationBuilder
    {
        IExpression<Article, IArticleBuilder> ById(int id);
        IExpression<Article, IArticleBuilder> ByName(string name);
        IExpression<Article, IArticleBuilder> ByCategoryType(CategoryTypes categoryType);
    }
}
