using stefan_academy_vanilla_charp.Books.Dtos;
using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Books.Services
{
    internal class BookService
    {
        private readonly List<Book> books;

        public BookService()
        {
            StudentService service = new StudentService();
            //books = new List<Models.Book>
            {

                //new Models.Book(,"test",new DateTime(2026,4,6))
            };
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

        //Mappers

        public Book BookCreateRequestToBook(BookCreateRequest request)
        {
            return new Book(request.StudentId,request.BookName,request.CreatedAt);
        }

        public BookCreateResponse BookToBookCreateResponse(Book book)
        {
            return new BookCreateResponse()
            {
                StudentId = book.StudentId,
                BookName = book.BookName,
                CreatedAt = book.CreatedAt
            };
        }

        public Book BookUpdateRequestToBook(BookUpdateRequest request) {
            return new Book(request.StudentId, request.BookName, request.CreatedAt);
        }

        public BookUpdateResponse BookToBookUpdateResponse(Book book)
        {
            return new BookUpdateResponse()
            {
                StudentId = book.StudentId,
                BookName = book.BookName,
                CreatedAt = book.CreatedAt
            };
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
            if (books.Count + 1 > books.Capacity)
            {
                throw new ArgumentException("Baze de data este plina");
            }

            Book newBook = BookCreateRequestToBook(request);

            if (FindById(newBook.Id) != null)
            {
                throw new ArgumentException("Cartea se afla deja in baza de date");
            }

            books.Add(newBook);
            return BookToBookCreateResponse(newBook);
        }

        public BookUpdateResponse UpdateBook(Guid id, BookUpdateRequest request)
        {
            Book book = FindById(id);
            if (book == null)
            {
                throw new ArgumentException("Cartea nu exista in baza de date");
            }

            book.StudentId = request.StudentId;
            book.BookName = request.BookName;
            book.CreatedAt = request.CreatedAt;

            return BookToBookUpdateResponse(book);
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
    }
}