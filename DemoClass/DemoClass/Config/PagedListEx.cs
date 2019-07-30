using DemoClass.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoClass.Config
{
    public static class PagedListEx
    {
        public static async Task<PageListContract<T>> Paginate<T>(this IQueryable<T> source, int skip, int take)
        {
            var total = source.Count();
            int totalPages = total / take;
            if (total % take > 0)
                totalPages++;
            return new PageListContract<T>
            {
                TotalCount = total,
                PageIndex = skip,
                PageSize = take,
                TotalPages = totalPages,
                Sources = total == 0 ? new List<T>() : await source.Skip((skip - 1) * take).Take(take).ToListAsync()
            };
        }
    }
}
