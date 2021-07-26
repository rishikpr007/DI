using DI.Data;
using DI.Infrastructure;
using DI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Product.ToList();

        }

        public Product GetByID(int Id)
        {
            return _context.Product.FirstOrDefault(u => u.ProductID==Id);
        }
    }
}
