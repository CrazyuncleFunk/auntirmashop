using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aunt_Irma_Shop.Models
{
    public class TempCart
    {
        public TempCart()
        {
            Count = 0;
        }
        public int ItemId { get; set; }
        [NotMapped]
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than 0!")]
        public int Count { get; set; }
    }
}
