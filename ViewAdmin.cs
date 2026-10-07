using stefan_academy_vanilla_charp.Common.Exceptions;
using stefan_academy_vanilla_charp.Users.Dtos;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Repositories;
using stefan_academy_vanilla_charp.Users.Services;

namespace stefan_academy_vanilla_charp
{
    public class ViewAdmin
    {
        private UserService userService = new(UserRepository.Instance);
        private User loggedUser;
        
        public ViewAdmin(User user) 
        {
            loggedUser = user;
        }

        public void Viewer()
        {
            int tasta;
            do
            {
                Console.WriteLine("Apasati tasta 0 pentru a iesi");
                Console.WriteLine("Apasati tasta 1 pentru a adauga un student");

                if (!Int32.TryParse(Console.ReadLine(), out tasta))
                {
                    InputGresit();
                    continue;
                }

                switch (tasta) 
                {
                    case 0: return;
                    case 1: AdaugareStudent(); break;
                    default: InputGresit(); break;
                }
            } while (tasta != 0);
        }

        public void InputGresit()
        {
            Console.WriteLine("Ati introdus un caracter nepermis!");
        }

        public void AdaugareStudent()
        {
            Console.WriteLine("Numele: ");
            string nume = Console.ReadLine();

            Console.WriteLine("Prenumele: ");
            string prenume = Console.ReadLine();

            Console.WriteLine("Emailul: ");
            string email = Console.ReadLine();

            Console.WriteLine("Varsta: ");
            int varsta;
            Int32.TryParse(Console.ReadLine(), out varsta);

            try
            {
                StudentCreateRequest request = new(prenume, nume, email, varsta);
                userService.CreateStudent(request);
                Console.WriteLine("Studentul " + prenume + " " + nume + " a fost adaugat");
            }catch(AcademyException ex)
            {
                Console.WriteLine(ex.MesajPentruUtilizator);
            }
        }
    }
}
