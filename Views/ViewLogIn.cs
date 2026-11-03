using stefan_academy_vanilla_charp.Books.Services.Command;
using stefan_academy_vanilla_charp.Books.Services.Query;
using stefan_academy_vanilla_charp.Courses.Services.Command;
using stefan_academy_vanilla_charp.Courses.Services.Query;
using stefan_academy_vanilla_charp.Enrolments.Services.Command;
using stefan_academy_vanilla_charp.Enrolments.Services.Query;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Services.Query;

namespace stefan_academy_vanilla_charp
{
    public class ViewLogIn
    {
        private readonly IBookQueryService bookQueryService;
        private readonly IBookCommandService bookCommandService;
        private readonly ICourseQueryService courseQueryService;
        private readonly ICourseCommandService courseCommandService;
        private readonly IEnrolmentQueryService enrolmentQueryService;
        private readonly IEnrolmentCommandService enrolmentCommandService;
        private readonly IUserQueryService userQueryService;

        public ViewLogIn(IBookQueryService bookQueryService, IBookCommandService bookCommandService,
            ICourseQueryService courseQueryService, ICourseCommandService courseCommandService,
            IEnrolmentQueryService enrolmentQueryService, IEnrolmentCommandService enrolmentCommandService,
            IUserQueryService userQueryService)
        {
            this.bookQueryService = bookQueryService;
            this.bookCommandService = bookCommandService;
            this.courseQueryService = courseQueryService;
            this.courseCommandService = courseCommandService;
            this.enrolmentQueryService = enrolmentQueryService;
            this.enrolmentCommandService = enrolmentCommandService;
            this.userQueryService = userQueryService;
        }

        public void Logger()
        {
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

            User user = userQueryService.GetUserByFirstAndLastName(firstName, lastName);

            if (user == null)
            {
                throw new ArgumentException("Userul nu aceste credentiale nu exista");
            }

            if (user is Admin a)
            {
                Console.Write("Parola: ");
                string password = Console.ReadLine();

                if (a.Password == password)
                {
                    ViewAdmin viewer = new(user);
                    Console.WriteLine("Logat cu succes!");
                    viewer.Viewer();
                }
                else
                {
                    throw new ArgumentException("Parola gresita!");
                }

            }
            else if (user is Teacher t)
            {
                Console.Write("Parola: ");
                string password = Console.ReadLine();

                if (t.Password == password)
                {
                    //viewTeacher
                }
                else
                {
                    throw new ArgumentException("Parola gresita!");
                }
            }
            else if (user is Student)
            {
                ViewStudent viewer = new(user, bookQueryService, bookCommandService, courseQueryService, courseCommandService,
                    enrolmentQueryService, enrolmentCommandService);
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
