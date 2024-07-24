using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProject.Entities;

namespace APIProject.Service
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public Book CreateBook(Book book);
        public Book UpdateBook(Book book);
        public Book DeleteBook(int id);
    }
}