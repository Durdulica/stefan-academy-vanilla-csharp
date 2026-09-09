namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public record AdminCreateResponse(Guid Id, string FirstName, string LastName, string Email, int Age, int Salary, string Password);
}