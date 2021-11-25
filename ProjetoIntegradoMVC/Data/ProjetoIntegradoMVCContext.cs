using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoIntegradoMVC.Models
{
    public class ProjetoIntegradoMVCContext : DbContext
    {
        public ProjetoIntegradoMVCContext (DbContextOptions<ProjetoIntegradoMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
