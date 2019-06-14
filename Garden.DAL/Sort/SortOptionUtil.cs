using Garden.Core.DAL.Sort;
using System.Collections.Generic;
using System.Linq;

namespace Garden.DAL.Sort
{
    public static class SortOptionUtil
    {
        public static string GetQuery(this List<SortingOption> sortingOptions)
        {
            return string.Join(" ,", sortingOptions.Select(item => item.GetStringForQuery()));
        }

        public static string GetStringForQuery(this SortingOption sortingOptions)
        {
            return string.Format("{0} {1}", sortingOptions.ColumnName,
                sortingOptions.SortingType == SortingType.Desc ? "descending" : "ascending");
        }
    }
}
