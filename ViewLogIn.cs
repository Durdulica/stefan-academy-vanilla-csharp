using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Repositories;
using stefan_academy_vanilla_charp.Users.Services;

namespace stefan_academy_vanilla_charp
{
    public class ViewLogIn
    {
        public void Logger()
        {
            UserRepository repository = UserRepository.Instance;
            repository.Subscribe(new NotificatorConsola());
            UserService service = new(repository);

            Console.WriteLine("==================LOG IN==================");
            Console.Write("\n");

            Console.Write("Numele: ");
            string lastName = Console.ReadLine();

            Console.Write("Prenumele: ");
            string firstName = Console.ReadLine();

            if(lastName == null || firstName == null) 
            {
                Console.WriteLine("Input gresit!!!!!");
                return;
            }

            if (lastName.Length == 0 || firstName.Length == 0) 
            {
                Console.WriteLine("Numele si prenumele trebuie introduse!");
                return;
            }

            User user = service.GetUserByFirstAndLastName(firstName, lastName);

            if (user == null)
            {
                throw new ArgumentException("Userul nu aceste credentiale nu exista");
            }

            Student s = user as Student;
            Teacher t = user as Teacher;
            Admin a = user as Admin;


            if (a != null)
            {
                Console.Write("Parola: ");
                string password = Console.ReadLine();

                if (a.Password == password)
                {
                    //viewAdmin
                }
                else
                {
                    throw new ArgumentException("Parola gresita!");
                }

            }
            else if (t != null)
            {
                Console.Write("Parola: ");
                string password = Console.ReadLine();

                if (t.Password == password) {
                    //viewTeacher
                }
                else
                {
                    throw new ArgumentException("Parola gresita!");
                }
            }
            else if (s != null) {
                ViewStudent viewer = new(user);
                Console.WriteLine("Logat cu succes!");
                viewer.Viewer();
            }
            else
            {
                throw new ArgumentException("Error on user type");
            }
        }
    }
}
