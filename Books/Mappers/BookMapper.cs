using stefan_academy_vanilla_charp.Books.Dtos;
using stefan_academy_vanilla_charp.Books.Models;

namespace stefan_academy_vanilla_charp.Books.Mappers
{
    public static class BookMapper
    {
        public static Book ToBook(BookCreateRequest request)
        {
            return new Book(request.StudentId, request.BookName, request.CreatedAt);
        }

        public static void ApplyUpdate(Book book, BookUpdateRequest request)
        {
            book.BookName = request.BookName;
        }

        public static BookCreateResponse ToCreateResponse(Book book)
        {
            return new BookCreateResponse(book.Id, book.StudentId, book.BookName, book.CreatedAt);
        }

        public static BookUpdateResponse ToUpdateResponse(Book book)
        {
            return new BookUpdateResponse(book.Id, book.BookName, book.CreatedAt);
        }
    }
}
