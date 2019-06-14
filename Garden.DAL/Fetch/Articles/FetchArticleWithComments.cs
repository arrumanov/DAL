using System.Linq;
using Garden.Core.DAL.Fetch.Articles;
using Garden.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Garden.DAL.Fetch.Articles
{
    public class FetchArticleWithComments : IFetchArticleWithComments
    {
        public IQueryable<Article> AcceptQuery(IQueryable<Article> query)
        {
            return query
                .Include(item => item.Comments);
        }
    }
}
