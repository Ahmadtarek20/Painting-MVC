using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallingMvc.Models
{
    [MetadataType(typeof(CustomerProductMetadata))]
    public class Product
    {
        [Key, Display(Name = "ID")]
        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)] //lel id
        public int ProductId { get; set; }
        [Required, StringLength(40), Display(Name = "Name")]
        public string Name { get; set; }
        [Required, StringLength(40), Display(Name = "Description")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/mm/yy}",ApplyFormatInEditMode =true)]
        public DateTime Data { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Carts> Carts { get; set; }
        public ICollection<Photo> Photos { get; set; }

    }
    public partial class CustomerProductMetadata
    {
        [StringLength(10, MinimumLength = 5)]
        [RegularExpression(@"^(([A-za-z]+[/s]{1}[A-za-z]+)|([A-za-z]+))$", ErrorMessage = "erorr alfa")]
        [Required]
        // [Remote("IsUserName","Product",ErrorMessage ="eror of ther is User login")]
        //m7taga el javascrept enable
        public string Name { get; set; }

        [Range(1, 100000)]
        public Nullable<int> Price { get; set; }

         [DisplayFormat(DataFormatString ="{0:d}",ApplyFormatInEditMode =true)]
         public Nullable<System.DateTime> Data { get; set; }
    }
}