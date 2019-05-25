using AccountManager.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    public static class QueryExtension
    {
        public static Pagged<T> Pagging<T>(this IQueryable<T> items,
            int page, int rowsPage)
        {
            if (page == 0) page = 1;
            if (rowsPage == 0) rowsPage = 10;

            return new Pagged<T>()
            {
                CurrentPage = page,
                Data = items.Skip((page -1) * rowsPage)
                        .Take(rowsPage),
                Request = new { page, rowsPage},
                TotalPages = (int)Math.Ceiling((double)items.Count() / (double)rowsPage ),
                TotalRows = items.Count()
            };
        }
    }
}
