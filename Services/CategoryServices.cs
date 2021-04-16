using AssignmentCSharp4_EFCodeFirst.Context;
using AssignmentCSharp4_EFCodeFirst.IServices;
using AssignmentCSharp4_EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentCSharp4_EFCodeFirst.Services
{
    public class CategoryServices: ICategoryServices
    {
        private readonly DatabaseContext _context;
        private List<Category> _lstCategory;
        public CategoryServices()
        {

        }
        public CategoryServices(DatabaseContext context)
        {

           // _lstCategory = new List<Category>();
            _context = context;
            GetLstCategory();
        }
        public List<Category> GetLstCategory()
        {
            _lstCategory = _context.Categorys.ToList();
            return _lstCategory;
        }
        public void addCategory(Category category)
        {
            _context.Categorys.Add(category);
            _context.SaveChanges();
        }
        public void editCategory(Category category)
        {
            var categories = _context.Categorys.Find(category.Id);
            categories.NameCategory = category.NameCategory;
            _context.Categorys.Update(categories);
            _context.SaveChanges();
        }
        public Category findId(int categoryId)
        {
            return _context.Categorys.SingleOrDefault(c => c.Id == categoryId);
        }
        public bool checkIdcategory(int categoryId)
        {
            return _lstCategory.Any(x => x.Id == categoryId);
        }
        public Category getCategoryObj(int categoryID)
        {
            return _lstCategory.Where(x => x.Id == categoryID).FirstOrDefault();
        }
    }
}
