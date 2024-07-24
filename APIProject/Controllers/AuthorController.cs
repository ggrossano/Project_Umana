using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProject.Entities;
using APIProject.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAll()
        {
            var authors = authorService.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetById(int id)
        {
            Author author = authorService.GetById(id);

            if(author == null){
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(Author author)
        {
            Author newAuthor = authorService.AddAuthor(author);

            return Ok(newAuthor);
        }

        [HttpPut]
        public async Task<ActionResult<Author>> UpdateAuthor(Author author)
        {

            var createAuthor = authorService.UpdateAuthor(author);

            return Ok(createAuthor);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var deletedAuthor = authorService.DeleteAuthor(id);
            return Ok(deletedAuthor);
        }
}
}