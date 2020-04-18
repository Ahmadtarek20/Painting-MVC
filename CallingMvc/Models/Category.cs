using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallingMvc.Models
{
    public class Category
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public int CareguryId { get; set; }
        [Required, Display(Name = "Category Name")]
        [StringLength(10, MinimumLength = 5)]
        public string Categury_Name { get; set; }
        public List<Product> Products { get; set; }
    }
}