using Garden.Core.DAL.Repository;
using Garden.Core.Entities;

namespace Garden.DAL.Repository
{
    public class ArticleRepository : CrudRepository<Article>, IArticleRepository
    {
    }
}
