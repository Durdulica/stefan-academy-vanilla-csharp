using stefan_academy_vanilla_charp.Books.Models;

namespace stefan_academy_vanilla_charp.Books.Services.Query
{
    public interface IBookQueryService
    {
        Book GetBook(Guid studentId, string bookName);

        List<Book> GetBooksByStudentId(Guid studentId);
    }
}
