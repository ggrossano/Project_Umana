using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProject.Entities;
using APIProject.Repo;

namespace APIProject.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepo DataAcc;

        public BookService(IBookRepo datAcc)
        {
            this.DataAcc = datAcc;
        }

        public List<Book> GetAll()
        {
            return DataAcc.GetAll();
        }

        public Book GetById(int id){
            return DataAcc.GetById(id);
        }

        public Book CreateBook(Book book)
        {
            return DataAcc.CreateBook(book);
        }

        public Book UpdateBook(Book book)
        {
            return DataAcc.UpdateBook(book);
        }

        public Book DeleteBook(int id)
        {
            return DataAcc.DeleteBook(id);
        }

    }
}