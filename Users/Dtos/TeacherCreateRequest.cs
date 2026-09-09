namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public record TeacherCreateRequest(string FirstName, string LastName,
        string Email, int Age, int Salary, int WorkHours, string Password);
}