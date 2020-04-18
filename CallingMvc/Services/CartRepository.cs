using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CallingMvc.Models;

namespace CallingMvc.Services
{
    public class CartRepository : ICarts
    {
        public int AddCart(Carts carts)
        {
            throw new NotImplementedException();
        }

        public void DeleteCart(int id)
        {
            throw new NotImplementedException();
        }

        public Carts GetCart(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carts> GetCarts()
        {
            throw new NotImplementedException();
        }

        public void ProductDetails(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}