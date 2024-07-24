using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using APIProject.Entities;

namespace APIProject.Repo
{
    public interface IBookRepo
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public Book CreateBook(Book book);
        public Book UpdateBook(Book book);
        public Book DeleteBook(int id);
    }
}