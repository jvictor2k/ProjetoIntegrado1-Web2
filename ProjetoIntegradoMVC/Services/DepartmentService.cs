using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoIntegradoMVC.Models;

namespace ProjetoIntegradoMVC.Services
{
    public class DepartmentService
    {
        private readonly ProjetoIntegradoMVCContext _context;

        public DepartmentService(ProjetoIntegradoMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
