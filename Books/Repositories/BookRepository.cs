using stefan_academy_vanilla_charp.Books.Models;

namespace stefan_academy_vanilla_charp.Books.Repositories
{
    public class BookRepository
    {
        private readonly List<Book> books = new();

        public BookRepository()
        {
            Read();
        }

        public Book FindById(Guid id)
        {
            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public Book FindByStudentAndName(Guid studentId, string bookName)
        {
            foreach (Book book in books)
            {
                if (book.StudentId == studentId && book.BookName.Contains(bookName))
                {
                    return book;
                }
            }
            return null;
        }

        public List<Book> FindByStudentId(Guid studentId)
        {
            List<Book> studentBooks = new();

            foreach (Book book in books)
            {
                if (book.StudentId == studentId)
                {
                    studentBooks.Add(book);
                }
            }

            return studentBooks;
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public void Remove(Book book)
        {
            books.Remove(book);
        }

        public void Save()
        {
            using (var writer = new StreamWriter(Path()))
            {
                writer.Write(ToText());
            }
        }

        private void Read()
        {
            using (var reader = new StreamReader(Path()))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    books.Add(new Book(line));
                }
            }
        }

        private string ToText()
        {
            string list = "";
            for (int i = 0; i < books.Count; i++)
            {
                list += books[i].Id + "," + books[i].StudentId + "," + books[i].BookName + "," + books[i].CreatedAt.ToString("yyyy-MM-dd");
                if (i + 1 < books.Count)
                {
                    list += "\n";
                }
            }
            return list;
        }

        private static string Path()
        {
            return System.IO.Path.Combine("..", "..", "..", "Data", "books.txt");
        }
    }
}
