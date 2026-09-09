namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public record AdminUpdateResponse(Guid Id, string FirstName, string LastName, string Email, int Salary, string Password);
}