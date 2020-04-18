using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallingMvc.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}