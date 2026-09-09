namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public record TeacherUpdateResponse(Guid Id, string FirstName, string LastName,
        string Email, int Salary, int WorkHours, string Password);
}