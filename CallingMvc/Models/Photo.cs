﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallingMvc.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}