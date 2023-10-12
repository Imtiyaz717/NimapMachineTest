using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MachineTest1.Models
{
    public class CategoryProductVM
    {
        [Key]
        [DisplayName("Sr No.")]
        public int Id { get; set; }

        
        public int ProductID { get; set; }

        
        public string ProductName { get; set; }

        
        public int CategoryID { get; set; }

        
        public string CategoryName { get; set; }
    }
}