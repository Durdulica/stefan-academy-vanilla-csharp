using stefan_academy_vanilla_charp.Books.Dtos;
using stefan_academy_vanilla_charp.Books.Mappers;
using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Books.Repositories;
using stefan_academy_vanilla_charp.Common.Exceptions;

namespace stefan_academy_vanilla_charp.Books.Services
{
    public class BookService
    {
        private readonly BookRepository repository;

        public BookService(BookRepository repository)
        {
            this.repository = repository;
        }

        public Book GetBook(Guid studentId, string bookName)
        {
            return repository.FindByStudentAndName(studentId, bookName);
        }

        public List<Book> GetBooksByStudentId(Guid studentId)
        {
            return repository.FindByStudentId(studentId);
        }

        public BookCreateResponse CreateBook(BookCreateRequest request)
        {
            Book newBook = BookMapper.ToBook(request);

            if (repository.FindByStudentAndName != null)
            {
                throw new DuplicateException("Cartea", newBook.BookName + " id student" + newBook.StudentId);
            }

            repository.Add(newBook);

            return BookMapper.ToCreateResponse(newBook);
        }

        public BookUpdateResponse UpdateBook(Guid id, BookUpdateRequest request)
        {
            Book book = repository.FindById(id);
            if (book == null)
            {
                throw new NotFoundException("Cartea", id.ToString());
            }

            BookMapper.ApplyUpdate(book, request);
            repository.Update(book);
            return BookMapper.ToUpdateResponse(book);
        }

        public void DeleteBook(Guid id)
        {
            Book book = repository.FindById(id);
            if (book == null)
            {
                throw new NotFoundException("Cartea", id.ToString());
            }

            repository.Remove(book);
        }
    }
}
