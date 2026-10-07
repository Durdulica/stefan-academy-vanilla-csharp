using stefan_academy_vanilla_charp.Books.Mappers;
using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Books.Repositories
{
    public class BookRepository : Repository<Book>
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

        public Book FindByStudentAndName(Guid studentId, string bookName)
        {
            foreach (Book book in Items)
            {
                if (book.StudentId == studentId && book.BookName == bookName)
                {
                    return book;
                }
            }
            return null;
        }

        public List<Book> FindByStudentId(Guid studentId)
        {
            List<Book> studentBooks = new();

            foreach (Book book in Items)
            {
                if (book.StudentId == studentId)
                {
                    studentBooks.Add(book);
                }
            }

            return studentBooks;
        }
    }
}
