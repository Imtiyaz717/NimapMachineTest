using MachineTest1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MachineTest1.EF
{
    public class MyContext : DbContext
    {
        public MyContext() : base("cs")
        {
            
        }

        public DbSet<CategoryMaster> TblCategoryMaster { get; set; }
        public DbSet<ProductMaster> TblProductMaster { get; set; }
    }
}