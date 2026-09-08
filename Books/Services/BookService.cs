using stefan_academy_vanilla_charp.Books.Dtos;
using stefan_academy_vanilla_charp.Books.Mappers;
using stefan_academy_vanilla_charp.Books.Models;

namespace stefan_academy_vanilla_charp.Books.Services
{
    public class BookService
    {
        private readonly List<Book> books = new List<Book>();

        public BookService()
        {
            ReadBooks();
        }

        //Finders

        public Book FindById(Guid Id)
        {
            foreach (Book b in books) {
                if (Id.CompareTo(b.Id) == 0)
                {
                    return b;
                }
            }
            return null;
        }

        public Book GetBook(Guid studentId, string bookName)
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

        public List<Book> GetBooksByStudentId(Guid studentId)
        {
            List<Book> studentBooks = new List<Book>();
            studentBooks.Capacity = books.Count;

            foreach (Book b in books)
            {
                if (b.StudentId == studentId)
                {
                    studentBooks.Add(b);
                }
            }

            return studentBooks;
        }

        //Afisare

        public void AfisareCarti()
        {
            foreach (Book b in books)
            {
                Console.WriteLine("Id student: " + b.StudentId + ", nume carte: " + b.BookName + ", data: " + b.CreatedAt);
            }
        }

        //CRUD

        public List<Book> Books
        {
            get { return books; }
        }

        public BookCreateResponse CreateBook(BookCreateRequest request)
        {
            Book newBook = BookMapper.ToBook(request);

            if (FindById(newBook.Id) != null)
            {
                throw new ArgumentException("Cartea se afla deja in baza de date");
            }

            books.Add(newBook);
            return BookMapper.ToCreateResponse(newBook);
        }

        private void ReadBooks()
        {
            string path = Path.Combine("..", "..", "..", "Data", "books.txt");

            using (var reader = new StreamReader(path))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    books.Add(new Book(line));
                }
            }
        }

        public BookUpdateResponse UpdateBook(Guid id, BookUpdateRequest request)
        {
            Book book = FindById(id);
            if (book == null)
            {
                throw new ArgumentException("Cartea nu exista in baza de date");
            }

            BookMapper.ApplyUpdate(book, request);

            return BookMapper.ToUpdateResponse(book);
        }

        public void DeleteBook(Guid id) { 
            for(int i = 0; i < books.Count; i++)
            {
                if (id.CompareTo(books[i].Id) == 0)
                {
                    books.RemoveAt(i);
                    return;
                }
            }
        }

        public string BooksListToString()
        {
            string list = "";
            for(int i = 0; i < books.Count; i++) 
            {
                if (i + 1 == books.Count)
                {
                    list += books[i].Id + "," + books[i].StudentId + "," + books[i].BookName + "," + books[i].CreatedAt.ToString("yyyy-MM-dd");
                }
                else
                {
                    list += books[i].Id + "," + books[i].StudentId + "," + books[i].BookName + "," + books[i].CreatedAt.ToString("yyyy-MM-dd") + "\n";
                }
            }
            return list;
        }

        public void Save()
        {
            string path = Path.Combine("..", "..", "..", "Data", "books.txt");
            using (var writer = new StreamWriter(path))
            {
                string list = BooksListToString();
                writer.Write(list);
            }
        }
    }
}