using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProject.Entities;
using APIProject.Repo;

namespace APIProject.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepo authorRepo;

        public AuthorService(IAuthorRepo authorRepo) {
            this.authorRepo = authorRepo;
        }
        public List<Author> GetAll()
        {
            return authorRepo.GetAll();
        }
        public Author GetById(int id)
        {
            return authorRepo.GetById(id);
        }
        public Author AddAuthor(Author author)
        {
            return authorRepo.AddAuthor(author);
        }
        public Author UpdateAuthor(Author author)
        {
            return authorRepo.UpdateAuthor(author);
        }
        public Author DeleteAuthor(int id)
        {
            return authorRepo.DeleteAuthor(id);
        }
    }
}