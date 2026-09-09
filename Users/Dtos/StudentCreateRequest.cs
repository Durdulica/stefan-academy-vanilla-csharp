namespace stefan_academy_vanilla_charp.Users.Models.Students.Dtos
{
    public record StudentCreateRequest(string FirstName, string LastName, string Email, int Age);
}