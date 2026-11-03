using stefan_academy_vanilla_charp.Books.Dtos;

namespace stefan_academy_vanilla_charp.Books.Services.Command
{
    public interface IBookCommandService
    {
        BookCreateResponse CreateBook(BookCreateRequest request);

        BookUpdateResponse UpdateBook(Guid id, BookUpdateRequest request);

        void DeleteBook(Guid id);
    }
}
