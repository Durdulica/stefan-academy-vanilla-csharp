using stefan_academy_vanilla_charp;
using stefan_academy_vanilla_charp.Books.Repositories;
using stefan_academy_vanilla_charp.Books.Services.Command;
using stefan_academy_vanilla_charp.Books.Services.Query;
using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Repositories;
using stefan_academy_vanilla_charp.Common.Exceptions;
using stefan_academy_vanilla_charp.Courses.Services.Query;
using stefan_academy_vanilla_charp.Courses.Repositories;
using stefan_academy_vanilla_charp.Enrolments.Services.Query;
using stefan_academy_vanilla_charp.Enrolments.Services.Command;
using stefan_academy_vanilla_charp.Enrolments.Repositories;
using stefan_academy_vanilla_charp.Users.Services.Query;
using stefan_academy_vanilla_charp.Users.Services.Command;

internal class Program
{
    public static void Main()
    {
        BookRepository bookRepository = BookRepository.Instance;
        CourseRepository courseRepository = CourseRepository.Instance;
        EnrolmentRepository enrolmentRepository = EnrolmentRepository.Instance;
        UserRepository userRepository = UserRepository.Instance;

        bookRepository.Subscribe(new NotificatorTest());
        bookRepository.Subscribe(new NotificatorFisier(Path.Combine("..", "..", "..", "Data", "jurnal.txt")));


        IBookQueryService bookQueryService = new BookQueryService(bookRepository);
        IBookCommandService bookCommandService = new BookCommandService(bookRepository);
        ICourseQueryService courseQueryService = new CourseQueryService(courseRepository);
        IEnrolmentQueryService enrolmentQueryService = new EnrolmentQueryService(enrolmentRepository);
        IEnrolmentCommandService enrolmentCommandService = new EnrolmentCommandService(enrolmentRepository);
        IUserQueryService userQueryService = new UserQueryService(userRepository);
        IUserCommandService userCommandService = new UserCommandService(userRepository);

        userRepository.Subscribe(new NotificatorConsola());

        try
        {
            ViewLogIn logIn = new(bookQueryService, bookCommandService, courseQueryService,
                enrolmentQueryService, enrolmentCommandService, userQueryService, userCommandService);
            logIn.Logger();
        }
        catch (AcademyException text)
        {
            Console.WriteLine(text.MesajPentruUtilizator);
        }
    }
}
