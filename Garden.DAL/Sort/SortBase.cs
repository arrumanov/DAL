using Garden.Core.DAL.Sort;
using Garden.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Garden.DAL.Sort
{
    public class SortBase<TEntity> : ISort<TEntity> where TEntity : Entity
    {
        internal List<SortingOption> _sortingOptions;

        public IQueryable<TEntity> AcceptQuery(IQueryable<TEntity> query)
        {
            if (_sortingOptions == null)
                return query;

            if (_sortingOptions != null && _sortingOptions.Count > 0)
            {
                query = query.OrderBy(_sortingOptions.GetQuery());
            }
            return query;
        }


        public void SetOptions(List<SortingOption> sortingOptions = null)
        {
            _sortingOptions = sortingOptions;
        }
    }
}
