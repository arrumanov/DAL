using Garden.Core.DAL.Fetch.Articles;
using Garden.Core.Entities;
using System.Linq;

namespace Garden.DAL.Fetch.Articles
{
    public class FetchArticleWithNothing : IFetchArticleWithNothing
    {
        public IQueryable<Article> AcceptQuery(IQueryable<Article> query)
        {
            return query;
        }
    }
}
