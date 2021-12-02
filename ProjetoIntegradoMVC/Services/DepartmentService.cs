using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoIntegradoMVC.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoIntegradoMVC.Services
{
    public class DepartmentService
    {
        private readonly ProjetoIntegradoMVCContext _context;

        public DepartmentService(ProjetoIntegradoMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
