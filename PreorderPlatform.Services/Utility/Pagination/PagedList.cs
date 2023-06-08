﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Service.Utility.Pagination
{
    public static class PagedList
    {
        public static IEnumerable<TObject> GetWithPaging<TObject>(this IEnumerable<TObject> source, int page, int pageSize, int safePageSizeLimit = PaginationConstant.MaxPageSize)
        where TObject : class
        {
            if (pageSize > safePageSizeLimit)
            {
                throw new Exception("Input page size is over safe limitation.");
            }

            if (source == null)
            {
                return Enumerable.Empty<TObject>();
            }

            pageSize = pageSize < 1 ? 1 : pageSize;
            page = page < 1 ? 1 : page;

            source = source
                .Skip(page == 1 ? 0 : pageSize * (page - 1)) // Paging
                .Take(pageSize); // Take only a number of items

            return source;
        }
    }
}
