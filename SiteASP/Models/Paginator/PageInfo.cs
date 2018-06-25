﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteASP.Models.Paginator
{
    public class PageInfo
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }

    public class IndexViewModel
    {
        public IEnumerable<Article> Articles { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}