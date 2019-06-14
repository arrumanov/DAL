using Garden.Core.DAL.Fetch;
using Garden.Core.DAL.Repository;
using Garden.Core.DAL.Sort;
using Garden.Core.DAL.Specification;

namespace Garden.Core.DAL
{
    public interface IStorage
    {
        IArticleRepository Articles { get; }
        ICommentRepository Comments { get; }
        TRepository GetRepository<TRepository>() where TRepository : IBaseRepository;
        TSpecificationBuilder GetSpecificationBuilder<TSpecificationBuilder>() 
            where TSpecificationBuilder : IBaseSpecificationBuilder;
        TFetch GetFetch<TFetch>() where TFetch : IBaseFetch;
        TSort GetSort<TSort>() where TSort : ISortBase;
        void Save();
    }
}
