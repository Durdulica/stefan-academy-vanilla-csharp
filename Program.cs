using stefan_academy_vanilla_charp;
using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Books.Repositories;
using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Repositories;

internal class Program
{
    public static void Main()
    {
        BookRepository.Instance.Subscribe(new NotificatorTest());
        BookRepository.Instance.Subscribe(new NotificatorFisier(Path.Combine("..", "..", "..", "Data", "jurnal.txt")));
        UserRepository.Instance.Subscribe(new NotificatorConsola());

        try
        {
            ViewLogIn logIn = new();
            logIn.Logger();
        }
        catch (ArgumentException text)
        {
            Console.WriteLine(text.Message);
        }
    }
}
