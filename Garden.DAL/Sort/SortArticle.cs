using Garden.Core.DAL.Sort;
using Garden.Core.DAL.Sort.EntitySortingTypes;
using Garden.Core.Entities;
using System;
using System.Collections.Generic;

namespace Garden.DAL.Sort
{
    public class SortArticle : SortBase<Article>, ISortArticle
    {
        public SortArticle()
        {

        }

        public ISortArticle AddSort(ArticleSortingType articleSortingType)
        {
            if (_sortingOptions == null)
                _sortingOptions = new List<SortingOption>();

            switch (articleSortingType)
            {
                case ArticleSortingType.DateDesc:
                    _sortingOptions.Add(new SortingOption()
                    {
                        ColumnName = "Date",
                        SortingType = SortingType.Desc
                    });
                    break;
                case ArticleSortingType.DateAsc:
                    _sortingOptions.Add(new SortingOption()
                    {
                        ColumnName = "Date",
                        SortingType = SortingType.Asc
                    });
                    break;
                case ArticleSortingType.NameDesc:
                    _sortingOptions.Add(new SortingOption()
                    {
                        ColumnName = "Name",
                        SortingType = SortingType. Desc
                    });
                    break;
                case ArticleSortingType.NameAsc:
                    _sortingOptions.Add(new SortingOption()
                    {
                        ColumnName = "Name",
                        SortingType = SortingType.Asc
                    });
                    break;
                case ArticleSortingType.DateDescNameAsc:
                    _sortingOptions.Add(new SortingOption()
                    {
                        ColumnName = "Date",
                        SortingType = SortingType.Desc
                    });
                    _sortingOptions.Add(new SortingOption()
                    {
                        ColumnName = "Name",
                        SortingType = SortingType.Asc
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(articleSortingType), articleSortingType, null);
            }

            return this;
        }
    }
}
