using stefan_academy_vanilla_charp;
using stefan_academy_vanilla_charp.Books.Repositories;
using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Repositories;
using stefan_academy_vanilla_charp.Common.Exceptions;
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
        catch (AcademyException text)
        {
            Console.WriteLine(text.MesajPentruUtilizator);
        }
    }
}
