using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Models.ViewModels
{
    public class ItemViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }

        public IEnumerable<SubCategory> SubCategoryList { get; set; }
        public Item Item { get; set; }

        
    }
}
