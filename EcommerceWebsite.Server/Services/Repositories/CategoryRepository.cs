using EcommerceWebsite.Server.Data;
using EcommerceWebsite.Server.Models;
using EcommerceWebsite.Server.Services.Infrastructures;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebsite.Server.Services.Repositories
{
    public class CategoryRepository : ICategory
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Categories.Count();
        }

        public void Delete(int id)
        {
            var catrgory = _context.Categories.FirstOrDefault(catrgory => catrgory.Id == id);
            if (catrgory != null)
            {
                _context.Categories.Remove(catrgory);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }

        public Category GetCategory(int id)
        {
            var catrgory = _context.Categories.FirstOrDefault(catrgory => catrgory.Id == id);
            if (catrgory != null)
            {
                return catrgory;
            }
            return null;
        }

        public void Insert(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Update(category);
        }
    }
}