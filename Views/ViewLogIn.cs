using stefan_academy_vanilla_charp.Books.Services.Command;
using stefan_academy_vanilla_charp.Books.Services.Query;
using stefan_academy_vanilla_charp.Common.Exceptions;
using stefan_academy_vanilla_charp.Courses.Services.Command;
using stefan_academy_vanilla_charp.Courses.Services.Query;
using stefan_academy_vanilla_charp.Enrolments.Services.Command;
using stefan_academy_vanilla_charp.Enrolments.Services.Query;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Services.Command;
using stefan_academy_vanilla_charp.Users.Services.Query;

namespace stefan_academy_vanilla_charp
{
    public class ViewLogIn
    {
        private readonly IBookQueryService bookQueryService;
        private readonly IBookCommandService bookCommandService;
        private readonly ICourseQueryService courseQueryService;
        private readonly IEnrolmentQueryService enrolmentQueryService;
        private readonly IEnrolmentCommandService enrolmentCommandService;
        private readonly IUserQueryService userQueryService;
        private readonly IUserCommandService userCommandService;

        public ViewLogIn(IBookQueryService bookQueryService, IBookCommandService bookCommandService,
            ICourseQueryService courseQueryService, ICourseCommandService courseCommandService,
            IEnrolmentQueryService enrolmentQueryService, IEnrolmentCommandService enrolmentCommandService,
            IUserQueryService userQueryService, IUserCommandService userCommandService)
        {
            this.bookQueryService = bookQueryService;
            this.bookCommandService = bookCommandService;
            this.courseQueryService = courseQueryService;
            this.enrolmentQueryService = enrolmentQueryService;
            this.enrolmentCommandService = enrolmentCommandService;
            this.userQueryService = userQueryService;
            this.userCommandService = userCommandService;
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
                throw new NotFoundException("Userul", " cu aceste credentiale nu exista");
            }
            
            if (user is Admin a)
            {
                Console.Write("Parola: ");
                string password = Console.ReadLine();

                if (a.Password == password)
                {
                    ViewAdmin viewer = new(user, userCommandService);
                    Console.WriteLine("Logat cu succes!");
                    viewer.Viewer();
                }
                else
                {
                    throw new ValidationException("Parola", " gresita!");
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
                    throw new ValidationException("Parola", " gresita!");
                }
            }
            else if (user is Student)
            {
                ViewStudent viewer = new(user, bookQueryService, bookCommandService, courseQueryService,
                    enrolmentQueryService, enrolmentCommandService);
                Console.WriteLine("Logat cu succes!");
                viewer.Viewer();
            }
            else
            {
                throw new NotFoundException("Error", " on user type");
            }
        }
    }
}
