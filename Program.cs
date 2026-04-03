using stefan_academy_vanilla_charp.Student.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        
        try
        {
            Student student = new Student("Scarlat", "Stefan", "stefanel.scarlat@gmail.com", 18);
        }
        catch(ArgumentException text) {
            Console.WriteLine(text);
        }
    }
}