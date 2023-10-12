using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachineTest1.Models
{
    public class CategoryMaster
    {
        [Key]
        //[DisplayName("Sr.No")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Name is Required!"),StringLength(100,ErrorMessage = "Length Should not be More than 100 Alphabet !")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductMaster> ProductMasters { get; set; }
    }
}