namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public record AdminUpdateRequest(string FirstName, string LastName, string Email, int Salary, string Password);
}