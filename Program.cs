using stefan_academy_vanilla_charp.Student.Dtos;
using stefan_academy_vanilla_charp.Student.Models;

internal class Program
{
    private static void Main(string[] args)
    {

        try
        {
            StudentService service = new StudentService();

            List<Student> students = service.Studenti;
            StudentCreateRequest req = new StudentCreateRequest("Ana", "Maria", "ana@gmail.com", 18);

            service.CreateStudent(req);
            service.AfisareStudenti();

            StudentUpdateRequest student = new StudentUpdateRequest("Stefanel", "Valentin", "stefanel.scarlat@gmail.com", 19);
            service.UpdateStudent(students[0].Id, student);
            service.AfisareStudenti();

        }
        catch (ArgumentException text) {
            Console.WriteLine(text);
        }

        
    }
}