using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using CallingMvc.Data;
using CallingMvc.Models;

namespace CallingMvc.Services
{
    public class CategoryRepository : ICategories
    {
        DataContextDB dataContextDB = new DataContextDB();
        public int AddCategory(Category category)
        {
            int result = -1;

            if (category != null)
            {
                dataContextDB.Categorys.Add(category);
                dataContextDB.SaveChanges();
                result = category.CareguryId;
            }
            return result;
            
        }

        public void DeleteCategory(int id)
        {
            Category category = dataContextDB.Categorys.Find(id);
            dataContextDB.Categorys.Remove(category);
            dataContextDB.SaveChanges();
        }

        public Category GetCategory(int id)
        {
            return dataContextDB.Categorys.Find(id);
        }

        public IEnumerable<Category> GetCategorys()
        {
            return dataContextDB.Categorys.ToList();
        }
    }
}