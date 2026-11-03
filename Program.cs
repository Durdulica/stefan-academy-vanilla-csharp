using stefan_academy_vanilla_charp;
using stefan_academy_vanilla_charp.Books.Repositories;
using stefan_academy_vanilla_charp.Books.Services.Command;
using stefan_academy_vanilla_charp.Books.Services.Query;
using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Repositories;
using stefan_academy_vanilla_charp.Common.Exceptions;
internal class Program
{
    public static void Main()
    {
        BookRepository bookRepository = BookRepository.Instance;
        bookRepository.Subscribe(new NotificatorTest());
        bookRepository.Subscribe(new NotificatorFisier(Path.Combine("..", "..", "..", "Data", "jurnal.txt")));

        IBookQueryService bookQueryService = new BookQueryService(bookRepository);
        IBookCommandService bookCommandService = new BookCommandService(bookRepository);

        UserRepository.Instance.Subscribe(new NotificatorConsola());

        try
        {
            ViewLogIn logIn = new(bookQueryService, bookCommandService);
            logIn.Logger();
        }
        catch (AcademyException text)
        {
            Console.WriteLine(text.MesajPentruUtilizator);
        }
    }
}
