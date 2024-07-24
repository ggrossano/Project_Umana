using APIProject.Data;
using APIProject.Entities;

namespace APIProject.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly DataContext _dataContext;

        public BookRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Book> GetAll()
        {
            return _dataContext.Books.ToList();
        }

        public Book GetById(int id)
        {
            Book existingBook = _dataContext.Books.Find(id) ?? throw new ArgumentException("Book not found");

            return existingBook;
        }

        public Book CreateBook(Book book)
        {
            if(book.AuthorId == 0)
                throw new ArgumentException("AuthorID is required!");

            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();
            return book;
        }

        public Book UpdateBook(Book book)
        {
            Book existingBook = _dataContext.Books.Find(book.Id) ?? throw new ArgumentException("Book not found");

            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.Year = book.Year;
            existingBook.AuthorId = book.AuthorId;
            existingBook.CategoryId = book.CategoryId;
            /* existingBook.Category = null; */

            _dataContext.SaveChanges();

            return existingBook;
        }

        public Book DeleteBook(int id)
        {
            Book existingBook = _dataContext.Books.Find(id) ?? throw new ArgumentException("Book not found");

            _dataContext.Books.Remove(existingBook);

            _dataContext.SaveChanges();

            return existingBook;
        }
    }
}