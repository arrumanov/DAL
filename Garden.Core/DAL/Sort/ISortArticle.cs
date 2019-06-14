using Garden.Core.DAL.Sort.EntitySortingTypes;
using Garden.Core.Entities;

namespace Garden.Core.DAL.Sort
{
    public interface ISortArticle : ISort<Article>
    {
        ISortArticle AddSort(ArticleSortingType articleSortingType);
    }
}
