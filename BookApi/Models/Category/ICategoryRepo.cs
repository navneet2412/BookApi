using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApi.Models
{
    internal interface ICategoryRepo
    {
        List<Category> GetAllCategory();
        Category GetCategoryById(int id);
        Category AddCategory(Category catogery);
        string DeleteCategory(int id);
        Category UpdateCategory(int id, Category category);
    }
}
