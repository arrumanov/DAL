using Garden.Core.DAL.Specification;
using Garden.Core.Entities;
using Garden.Core.Enums;

namespace Garden.DAL.Specification
{
    public class ArticleBuilder : BaseBuilder<Article>, IArticleBuilder
    {
        #region Expression

        public override IExpression<Article, ISpecificationBuilder<Article>> CreateExpression(
            BaseBuilder<Article> builder)
        {
            return new ArticleExpression((ArticleBuilder)builder);
        }

        private class ArticleExpression : MyExpression<Article, ArticleBuilder>
        {
            public ArticleExpression(ArticleBuilder abstractBuilder) : base(abstractBuilder)
            {
            }
        }

        #endregion

        public IExpression<Article, IArticleBuilder> ById(int id)
        {
            return Add(i => i.Id == id) as IExpression<Article, IArticleBuilder>;
        }

        public IExpression<Article, IArticleBuilder> ByName(string name)
        {
            return Add(i => i.Name == name) as IExpression<Article, IArticleBuilder>;
        }

        public IExpression<Article, IArticleBuilder> ByCategoryType(CategoryTypes categoryType)
        {
            return Add(i => i.CategoryType == categoryType) as IExpression<Article, IArticleBuilder>;
        }
    }
}
