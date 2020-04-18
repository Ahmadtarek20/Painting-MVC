using CallingMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingMvc.Services
{
    interface ICategories
    {
        int AddCategory(Category category);
        void DeleteCategory(int id);
        IEnumerable<Category> GetCategorys();
        Category GetCategory(int id);
    }
}
