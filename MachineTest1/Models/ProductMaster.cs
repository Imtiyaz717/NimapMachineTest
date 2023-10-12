using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachineTest1.Models
{
    public class ProductMaster
    {
        [Key] 

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Provide Product Name!"), StringLength(maximumLength: 100, ErrorMessage = "Length Should not be exceed more than 100 Alphabet", MinimumLength = 1)]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public virtual CategoryMaster CategoryMaster { get; set; }
    }
}