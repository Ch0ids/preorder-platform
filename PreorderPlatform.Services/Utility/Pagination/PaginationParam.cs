using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PreorderPlatform.Service.Utility.Pagination
{
    public class PaginationParam
    {
        private int _page = PaginationConstant.DefaultPage;

        public int Page
        {
            get => _page;
            set => _page = (value);
        }

        [FromQuery(Name = "page-size")]
        [DefaultValue(PaginationConstant.DefaultPageSize)]
        public int PageSize { get; set; } = PaginationConstant.DefaultPageSize;
    }
}
