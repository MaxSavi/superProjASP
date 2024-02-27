using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using superProjASP.Models;

namespace superProjASP.Data
{
    public class superProjASPContext : DbContext
    {
        public superProjASPContext (DbContextOptions<superProjASPContext> options)
            : base(options)
        {
        }

        //public DbSet<BookModel> BookModel { get; set; }
        public DbSet<PurchasedBook> PurchasedBook { get; set; }
        // = default!;
    }
}
