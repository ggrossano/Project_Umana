using Microsoft.AspNetCore.Mvc;
using APIProject.Entities;
using APIProject.Service;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            List<Category> category = CategoryService.GetAll();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Category category = CategoryService.GetById(id);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            var createCategory = CategoryService.CreateCategory(category);
            return Ok(createCategory);
            //return CreatedAtAction(nameof(GetById), new { id = createCategory.Id }, createCategory);

        }

        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            var createCategory = CategoryService.UpdateCategory(category);

            return Ok(createCategory);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var deletedCategory = CategoryService.DeleteCategory(id);
            return Ok(deletedCategory);
        }
    }
}