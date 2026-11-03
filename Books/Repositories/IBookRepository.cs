using stefan_academy_vanilla_charp.Books.Models;

namespace stefan_academy_vanilla_charp.Books.Repositories
{
    public interface IBookRepository
    {
        Book FindById(Guid id);

        Book FindByStudentAndName(Guid studentId, string bookName);

        List<Book> FindByStudentId(Guid studentId);

        void Add(Book book);

        void Update(Book book);

        void Remove(Book book);
    }
}
