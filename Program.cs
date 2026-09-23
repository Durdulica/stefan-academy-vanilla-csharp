using stefan_academy_vanilla_charp;

internal class Program
{
    public static void Main()
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
    