using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Books.Repositories;

namespace stefan_academy_vanilla_charp.Books.Services.Query
{
    public class BookQueryService : IBookQueryService
    {
        private readonly IBookRepository repository;

        public BookQueryService(IBookRepository repository)
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
    }
}
