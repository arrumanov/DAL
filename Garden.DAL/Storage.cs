using Garden.Core.DAL;
using Garden.Core.DAL.Fetch;
using Garden.Core.DAL.Repository;
using Garden.Core.DAL.Sort;
using Garden.Core.DAL.Specification;
using Garden.DAL.Repository;
using Microsoft.Extensions.Configuration;
using System;

namespace Garden.DAL
{
    public class Storage : IStorage, IDisposable
    {
        public StorageContext StorageContext { get; private set; }
        private readonly IServiceProvider _serviceProvider;

        private IArticleRepository _articleRepository;
        private ICommentRepository _commentRepository;

        public IArticleRepository Articles
        {
            get
            {
                if (_articleRepository == null)
                    _articleRepository = new ArticleRepository();
                _articleRepository.SetStorageContext(StorageContext);
                return _articleRepository;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository();
                _commentRepository.SetStorageContext(StorageContext);
                return _commentRepository;
            }
        }

        public Storage(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            StorageContext = new StorageContext(configuration.GetConnectionString("ProjectStaffingPlannerDatabase"));
            _serviceProvider = serviceProvider;
        }

        public TRepository GetRepository<TRepository>() where TRepository : IBaseRepository
        {
            var repository = (TRepository)_serviceProvider.GetService(typeof(TRepository));
            repository.SetStorageContext(StorageContext);
            return repository;
        }

        public TSpecificationBuilder GetSpecificationBuilder<TSpecificationBuilder>() 
            where TSpecificationBuilder : IBaseSpecificationBuilder
        {
            return (TSpecificationBuilder)_serviceProvider.GetService(typeof(TSpecificationBuilder));
        }

        public TFetch GetFetch<TFetch>() where TFetch : IBaseFetch
        {
            return (TFetch)_serviceProvider.GetService(typeof(TFetch));
        }

        public TSort GetSort<TSort>() where TSort : ISortBase
        {
            return (TSort)_serviceProvider.GetService(typeof(TSort));
        }

        public void Save()
        {
            StorageContext.SaveChanges();
        }

        #region Dispose
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    StorageContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
