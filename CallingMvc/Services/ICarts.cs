using CallingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingMvc.Services
{
    interface ICarts
    {
        int AddCart(Carts carts);
        void DeleteCart(int id);
        void ProductDetails(List<int> ids);
        IEnumerable<Carts> GetCarts();
        Carts GetCart(int id);
    }
}
