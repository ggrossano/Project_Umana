using APIProject.Data;
using APIProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repo
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly DataContext _dataContext;

        public AuthorRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Author> GetAll()
        {
            return _dataContext.Authors
                    .Include(a => a.Books)
                    .ToList();
        }

        public Author GetById(int id)
        {
            Author author = _dataContext.Authors
                            .Include(a => a.Books)
                            .FirstOrDefault(a => a.Id == id) ?? throw new KeyNotFoundException("Athor not found");

            return author;
        }

        public Author AddAuthor(Author newAuthor)
        {
            if (string.IsNullOrWhiteSpace(newAuthor.Name))
                throw new ArgumentException("Author name is required.");

            /* foreach (Book book in newAuthor.Books)
            {
                if (string.IsNullOrWhiteSpace(book.Title))
                    throw new ArgumentException("Author name is required.");

                book.Author = newAuthor;
            } */

            _dataContext.Authors.Add(newAuthor);
            _dataContext.SaveChanges();

            return newAuthor;
        }

        public Author UpdateAuthor(Author updatedAuthor)
        {
            Author existingAuthor = _dataContext.Authors
                                    .Include(a => a.Books) //include i libri associati
                                    .FirstOrDefault(a => a.Id == updatedAuthor.Id) // filtra l'ID per l'autore
                                    ?? throw new KeyNotFoundException("Author not found.");

            existingAuthor.Name = updatedAuthor.Name;

            //aggiunta di libri non presenti e aggiornamento dei libri gia presenti
            foreach (var updatedBook in updatedAuthor.Books)
            {
                var existingBook = existingAuthor.Books.FirstOrDefault(b => b.Id == updatedBook.Id);

                if (existingBook == null)
                {
                    existingAuthor.Books.Add(updatedBook);
                }
                else
                {
                    existingBook.Title = updatedBook.Title;
                    existingBook.Description = updatedBook.Description;
                    existingBook.Year = updatedBook.Year;
                    existingBook.AuthorId = updatedBook.AuthorId;
                    existingBook.CategoryId = updatedBook.CategoryId;
                }

            }
            // eliminazione dei libri non presenti nell'autore aggiornato
            foreach (var existingBook in existingAuthor.Books.ToList())
            {
                if (!updatedAuthor.Books.Any(b => b.Id == existingBook.Id))
                {
                    existingAuthor.Books.Remove(existingBook);
                }
            }

            _dataContext.Authors.Update(existingAuthor);
            _dataContext.SaveChanges();

            return existingAuthor;
        }

        public Author DeleteAuthor(int id)
        {
            var author = _dataContext.Authors.
                        FirstOrDefault(a => a.Id == id) ??
                        throw new KeyNotFoundException("Author not found.");

            // Rimuovi tutti i libri associati
            /* _dataContext.Books.RemoveRange(author.Books); */

            // Rimuovi l'autore
            _dataContext.Authors.Remove(author);
            _dataContext.SaveChanges();

            return author;
        }
    }
}