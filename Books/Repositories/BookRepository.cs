using stefan_academy_vanilla_charp.Books.Mappers;
using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Books.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private static BookRepository instance;

        public static BookRepository Instance
        {
            get 
            {
                if (instance == null) 
                {
                    instance = new BookRepository();
                }

                return instance;
            }
        }

        private BookRepository()
            : base(new BookTextMapper(), Path.Combine("..", "..", "..", "Data", "books.txt")) { }

        public Book FindByStudentAndName(Guid studentId, string bookName) => Items.FirstOrDefault(b => b.StudentId == studentId && b.BookName == bookName);

        public List<Book> FindByStudentId(Guid studentId) => Items.Where(b => b.StudentId == studentId).ToList();
    }
}
