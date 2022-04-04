﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Shared
{
    public class PageFilter
    {
        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 1;
    }
}
