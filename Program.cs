using stefan_academy_vanilla_charp;

internal class Program
{
    private static void Main()
    {
        try
        {
            ViewLogIn logIn = new();
            logIn.Logger();
        }
        catch (ArgumentException text)
        {
            Console.WriteLine(text);
        }
    }
}