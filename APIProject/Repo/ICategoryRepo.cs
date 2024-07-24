using APIProject.Entities;

namespace APIProject.Repo
{
    public interface ICategoryRepo
    {
        public List<Category> GetAll();
        public Category GetById(int id);
        public Category CreateCategory(Category category);
        public Category UpdateCategory(Category category);
        public Category DeleteCategory(int id);
    }
}