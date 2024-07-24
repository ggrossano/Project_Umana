using APIProject.Repo;
using APIProject.Entities;

namespace APIProject.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo DataAcc;

        public CategoryService(ICategoryRepo datAcc)
        {
            this.DataAcc = datAcc;
        }

        public List<Category> GetAll()
        {
            return DataAcc.GetAll();
        }

        public Category GetById(int id){
            return DataAcc.GetById(id);
        }

        public Category CreateCategory(Category category)
        {
            return DataAcc.CreateCategory(category);
        }

        public Category UpdateCategory(Category category)
        {
            return DataAcc.UpdateCategory(category);
        }

        public Category DeleteCategory(int id)
        {
            return DataAcc.DeleteCategory(id);
        }

    }
}