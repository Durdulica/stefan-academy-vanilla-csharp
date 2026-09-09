namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public record StudentCreateResponse(Guid Id, string FirstName, string LastName, string Email, int Age);
}