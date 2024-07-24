using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProject.Entities;

namespace APIProject.Repo
{
    public interface IAuthorRepo
    {
        public List<Author> GetAll();
        public Author GetById(int id);
        public Author AddAuthor(Author author);
        public Author UpdateAuthor(Author author);
        public Author DeleteAuthor(int id);
    }
}