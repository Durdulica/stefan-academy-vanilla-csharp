using stefan_academy_vanilla_charp.Books.Services;
using stefan_academy_vanilla_charp.Courses.Services;
using stefan_academy_vanilla_charp.Enrolments.Services;
using stefan_academy_vanilla_charp;
using stefan_academy_vanilla_charp.Users.Services;
using stefan_academy_vanilla_charp.Users.Models.Students.Models;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Dtos;
internal class Program
{
    private static void Main()
    {
        try
        {
            ViewLogIn logIn = new ViewLogIn();
            logIn.Logger();
        }
        catch (ArgumentException text)
        {
            Console.WriteLine(text);
        }
    }
}