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

        public DbSet<ProjetoIntegradoMVC.Models.Department> Department { get; set; }
    }
}
