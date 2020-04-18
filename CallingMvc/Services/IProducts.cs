using CallingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingMvc.Services
{
    interface IProducts
    {
        int AddProduct(Product product);
        void DeleteProduct(int id);
        Task<bool> SaveAll();
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
