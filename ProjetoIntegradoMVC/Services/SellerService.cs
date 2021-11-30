using ProjetoIntegradoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradoMVC.Services
{
    public class SellerService
    {
        private readonly ProjetoIntegradoMVCContext _context;

        public SellerService(ProjetoIntegradoMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}