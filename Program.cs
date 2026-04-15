using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Students.Models;
using stefan_academy_vanilla_charp.Books.Services;
using stefan_academy_vanilla_charp.Courses.Services;
using stefan_academy_vanilla_charp;
internal class Program
{
    private static void Main(string[] args)
    {

        
        try
        {
            ViewStudent view = new ViewStudent();
            view.Viewer();
        }
        catch (ArgumentException text)
        {
            Console.WriteLine(text);
        }
    }
}