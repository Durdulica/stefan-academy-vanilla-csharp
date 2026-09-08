namespace stefan_academy_vanilla_charp.Books.Dtos
{
    public record BookCreateRequest(Guid StudentId, string BookName, DateTime CreatedAt);
}
