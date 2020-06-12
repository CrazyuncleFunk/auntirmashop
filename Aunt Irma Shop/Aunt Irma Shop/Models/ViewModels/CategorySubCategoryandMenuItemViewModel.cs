using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Models.ViewModels
{
    public class CategorySubCategoryandMenuItemViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }

        public IEnumerable<SubCategory> SubCategoryList { get; set; }
        public MenuItem MenuItem { get; set; }

        
    }
}
