﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Item> Item { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<SubCategory> SubCategory { get; set; }
        public IEnumerable<Coupon> Coupon { get; set; }
    }
}