using stefan_academy_vanilla_charp.Users.Services;
using stefan_academy_vanilla_charp.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stefan_academy_vanilla_charp.Users.Models.Students.Models;
using stefan_academy_vanilla_charp.Users.Models.Teachers.Models;
using stefan_academy_vanilla_charp.Users.Models.Admins.Models;

namespace stefan_academy_vanilla_charp
{
    public class ViewLogIn
    {
        public void Logger()
        {
            UserService service = new UserService();

            Console.WriteLine("==================LOG IN==================");
            Console.Write("\n");

            Console.Write("Numele: ");
            string lastName = Console.ReadLine();

            Console.Write("Prenumele: ");
            string firstName = Console.ReadLine();

            User user = service.GetByFirstAndLastName(firstName, lastName);

            if (user == null) {
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
                ViewStudent viewer = new ViewStudent(user);
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
