using APIProject.Data;
using APIProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly DataContext _dataContext;

        public CategoryRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Category> GetAll()
        {
            return _dataContext.Categories
            .Include(c => c.Books)
            .ToList();
        }

        public Category GetById(int id)
        {
            Category existingCategory = _dataContext.Categories
                                        .Include(c => c.Books)
                                        .FirstOrDefault(c => c.Id == id)
                                         ?? throw new ArgumentException("Category not found");

            return existingCategory;
        }

        public Category CreateCategory(Category category)
        {
            _dataContext.Categories.Add(category);
            _dataContext.SaveChanges();
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            Category existingCategory = _dataContext.Categories.Find(category.Id) ?? throw new ArgumentException("Category not found");

            existingCategory.Name = category.Name;
            _dataContext.SaveChanges();

            return existingCategory;
        }

        public Category DeleteCategory(int id)
        {
            Category existingCategory = _dataContext.Categories.Find(id) ?? throw new ArgumentException("Category not found");

            _dataContext.Categories.Remove(existingCategory);

            _dataContext.SaveChanges();

            return existingCategory;
        }
    
    }
}