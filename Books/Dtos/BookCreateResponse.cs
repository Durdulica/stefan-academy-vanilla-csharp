namespace stefan_academy_vanilla_charp.Books.Dtos
{
    public record BookCreateResponse(Guid Id, Guid StudentId, string BookName, DateTime CreatedAt);
}
