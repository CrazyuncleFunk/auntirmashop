using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Models.ViewModels
{
    public class CategoryAndSubCategoryViewModel
    {

        public IEnumerable<Category> CategoryList { get; set; }
        public SubCategory SubCategory { get; set; }
        [NotMapped]
        public List<string> SubCategoryList { get; set; }
        public string StatusMessage { get; set; }
    }
}
