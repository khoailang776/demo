using System.Collections.Generic;

namespace DemoClass.Contracts
{
    public class PageListContract<TEntity>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public IList<TEntity> Sources { get; set; }
    }
}
