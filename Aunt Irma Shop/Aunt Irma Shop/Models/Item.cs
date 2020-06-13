using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
        [Required]
        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public double Price { get; set; }
    }
}
