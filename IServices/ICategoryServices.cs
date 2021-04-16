using AssignmentCSharp4_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.IServices
{
    public interface ICategoryServices
    {
        List<Category> GetLstCategory();
        void addCategory(Category categoryId);
        void editCategory(Category category);
        bool checkIdcategory(int categoryId);
        Category getCategoryObj(int categoryId);
        Category findId(int categoryId);
    }
}
