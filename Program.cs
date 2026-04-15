using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Student.Dtos;
using stefan_academy_vanilla_charp.Student.Models;
using stefan_academy_vanilla_charp.Books.Services;
internal class Program
{
    private static void Main(string[] args)
    {

        try
        {
            BookService service = new BookService();
            service.Save();
        }
        catch (ArgumentException text)
        {
            Console.WriteLine(text);
        }
    }
}