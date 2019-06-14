//using Garden.Core.DAL;
//using Garden.Core.DAL.Repository;
//using Garden.Core.Entities;
//using System.Collections.Generic;
//using System.Linq;

//namespace Garden.Mock
//{
//    public class ArticleRepository : IArticleRepository
//    {
//        public readonly IList<Article> items;

//        public ArticleRepository()
//        {
//            this.items = new List<Article>();
//            this.items.Add(new Article() { Id = 1, Name = "Mock item 1", Content = string.Empty });
//            this.items.Add(new Article() { Id = 2, Name = "Mock item 2", Content = string.Empty });
//            this.items.Add(new Article() { Id = 3, Name = "Mock item 3", Content = string.Empty });
//        }

//        public void SetStorageContext(IStorageContext storageContext)
//        {
//            // Do nothing
//        }

//        public IEnumerable<Article> All()
//        {
//            return this.items.OrderBy(i => i.Name);
//        }
//    }
//}
