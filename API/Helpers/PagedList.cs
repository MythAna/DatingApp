using Microsoft.EntityFrameworkCore;

namespace API.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPages = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            PageSize = PageSize;
            TotalCount = count;
            AddRange(items);
        }

       public int CurrentPages { get; set; } 
       public int TotalPages { get; set; }
       public int PageSize { get; set; }
       public int TotalCount { get; set; }

       public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source,
            int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);        
        }
    }
}