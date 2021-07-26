using DI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Infrastructure
{
    public interface IProductRepo
    {
        List<Product> GetAll();
        Product GetByID(int Id);
    }
}
