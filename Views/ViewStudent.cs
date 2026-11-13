using stefan_academy_vanilla_charp.Books.Dtos;
using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Books.Services.Command;
using stefan_academy_vanilla_charp.Books.Services.Query;
using stefan_academy_vanilla_charp.Common.Exceptions;
using stefan_academy_vanilla_charp.Courses.Models;
using stefan_academy_vanilla_charp.Courses.Services.Query;
using stefan_academy_vanilla_charp.Enrolments.Dtos;
using stefan_academy_vanilla_charp.Enrolments.Services.Command;
using stefan_academy_vanilla_charp.Enrolments.Services.Query;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp
{
    public class ViewStudent
    {
        private readonly ICourseQueryService courseQueryService;
        private readonly IBookQueryService bookQueryService;
        private readonly IBookCommandService bookCommandService;
        private readonly IEnrolmentQueryService enrolmentQueryService;
        private  readonly IEnrolmentCommandService enrolmentCommandService;

        private User loggedUser;

        public ViewStudent(User user, IBookQueryService bookQueryService, IBookCommandService bookCommandService,
            ICourseQueryService courseQueryService, 
            IEnrolmentQueryService enrolmentQueryService, IEnrolmentCommandService enrolmentCommandService)
        {
            loggedUser = user;

            this.bookQueryService = bookQueryService;
            this.bookCommandService = bookCommandService;
            this.courseQueryService = courseQueryService;
            this.enrolmentQueryService = enrolmentQueryService;
            this.enrolmentCommandService = enrolmentCommandService;
        }

        public void Viewer()
        {
            int tasta;
            do
            {
                //Console.Clear();
                Console.WriteLine("Apasati tasta 0 pentru a iesi");
                Console.WriteLine("Apasati tasta 1 pentru a lucra cu CARTI");
                Console.WriteLine("Apasati tasta 2 pentru a lucra cu CURSURI");
                Console.WriteLine("Apasati tasta 3 pentru a vedea statisticile");

                if(!Int32.TryParse(Console.ReadLine(), out tasta))
                {
                    InputGresit();
                    continue;
                }

                switch (tasta)
                {
                    case 0: return;
                    case 1: Carti(); break;
                    case 2: Cursuri(); break;
                    case 3: Statistici(); break;
                    default: InputGresit(); break;
                }
                //Console.Clear();
            }
            while (true);
        }

        //Domenii

        public void Carti()
        {
            Console.Clear();
            int tasta;
            do
            {
                Console.WriteLine("Apasati tasta 0 pentru a va intoarce");
                Console.WriteLine("Apasati tasta 1 pentru a afisa cartile detinute");
                Console.WriteLine("Apasati tasta 2 pentru a adauga o carte");
                Console.WriteLine("Apasati tasta 3 pentru a modifica o carte");
                Console.WriteLine("Apasati tasta 4 pentru a sterge o carte");

                if (!Int32.TryParse(Console.ReadLine(), out tasta))
                {
                    InputGresit();
                    continue;
                }

                switch (tasta)
                {
                    case 0: return;
                    case 1: AfisareCartiDetinute(); break;
                    case 2: AdaugareCarte(); break;
                    case 3: ModificareCarte(); break;
                    case 4: StergereCarte(); break;
                    default: InputGresit(); break;
                }
            }while(true);
        }

        public void Cursuri()
        {
            Console.Clear();
            int tasta;
            do
            {
                Console.WriteLine("Apasati tasta 0 pentru a va intoarce");
                Console.WriteLine("Apasati tasta 1 pentru a vedea cursurile");
                Console.WriteLine("Apasati tasta 2 pentru a va inscrie la un curs");
                Console.WriteLine("Apasati tasta 3 pentru a va dezabona de la un curs");
                Console.WriteLine("Apasati tasta 4 pentru a vedea cursurile la care va puteti inscrie");

                if (!Int32.TryParse(Console.ReadLine(), out tasta))
                {
                    InputGresit();
                    continue;
                }

                switch (tasta)
                {
                    case 0: return;
                    case 1: AfisareCursuri(); break;
                    case 2: InscriereCurs(); break;
                    case 3: DezabonareCurs(); break;
                    case 4: AfisareCursuriDisponibile(); break;
                    default: InputGresit(); break;
                }
            } while (true);
        }

        public void Statistici()
        {
            int tasta;
            do
            {
                Console.WriteLine("Apasati tasta 0 pentru a va intoarce");
                Console.WriteLine("Apasati tasta 1 pentru a vedea cursul cu cei mai multi elevi");
                Console.WriteLine("Apasati tasta 2 pentru a vedea cursurile pe departamente");
                Console.WriteLine("Apasati tasta 3 pentru a vedea cati studenti sunt inscrisi in fiecare departament");
                if (!Int32.TryParse(Console.ReadLine(), out tasta))
                {
                    InputGresit();
                    continue;
                }

                switch (tasta)
                {
                    case 0: return;
                    case 1: CursTopStudenti(); break;
                    case 2: CursuriPeDepartamente(); break;
                    case 3: StudentiPeDepartamente(); break;
                    default: InputGresit(); break;
                }
            } while (true);
        }

        //Functii

        public static void InputGresit() => Console.WriteLine("Ati introdus un caracter nepermis!");

        public void AfisareCursuri()
        {
            List<Course> courses = courseQueryService.GetCourseListByCourseId(enrolmentQueryService.GetCourseIdListByStudentId(loggedUser.Id));

            if (courses.Count > 0)
            {
                foreach (Course c in courses)
                {
                    Console.WriteLine("nume: " + c.Name + ", departament: " + c.Department);
                }
            }
            else
            {
                Console.WriteLine("Nu sunteti inscris la niciun curs");
            }
        }

        public void AfisareCursuriDisponibile()
        {
            HashSet<Guid> h = enrolmentQueryService.GetCourseIdsForStudent(loggedUser.Id);
            List<Course> courses = courseQueryService.GetCourses().Where(c => !h.Contains(c.Id)).ToList();

            if (courses.Count == 0)
            {
                Console.WriteLine("Sunteti inscris la toate cursurile");
            }

            courses.ForEach(c => Console.WriteLine("nume: " + c.Name + ", departament: " + c.Department));
        }

        public void AfisareCartiDetinute()
        {
            List<Book> books = bookQueryService.GetBooksByStudentId(loggedUser.Id);
            if (books.Count == 0)
            {
                Console.WriteLine("Nu ai nicio carte");
            }
            else
            {
                foreach (Book b in books)
                {
                    Console.WriteLine("Nume carte: " + b.BookName + " , ID carte: " + b.Id + " , adaugata in data: " + b.CreatedAt);
                }
            }
        }

        public void AdaugareCarte()
        {
            Console.Write("Tastati numele cartii: ");
            string text = Console.ReadLine();

            try
            {
                BookCreateRequest request = new BookCreateRequest(loggedUser.Id, text, DateTime.Now);
                BookCreateResponse response = bookCommandService.CreateBook(request);
                if (response != null)
                {
                    Console.WriteLine("Cartea " + response.BookName + " adaugata cu succes la data de " + response.CreatedAt.ToString("dd-MM-yyyy"));
                }
            }
            catch (AcademyException ex)
            {
                Console.WriteLine(ex.MesajPentruUtilizator);
            }
        }

        public void ModificareCarte()
        {
            Console.Write("Tastati numele cartii pe care doriti sa o modificati: ");
            string text = Console.ReadLine();
            Book book = bookQueryService.GetBook(loggedUser.Id, text);

            if (book == null)
            {
                Console.WriteLine("Cartea nu va apartine sau nu a fost gasita");
                return;
            }

            Console.Write("Tastati noul nume al cartii: ");
            string nume = Console.ReadLine();

            try
            {
                BookUpdateRequest request = new(nume);
                BookUpdateResponse response = bookCommandService.UpdateBook(book.Id, request);
            }
            catch (AcademyException ex)
            {
                Console.WriteLine(ex.MesajPentruUtilizator);
            }
        }

        public void StergereCarte()
        {
            Console.Write("Tastati numele cartii pe care doriti sa o stergeti: ");
            string text = Console.ReadLine();
            Book book = bookQueryService.GetBook(loggedUser.Id, text);

            if (book == null)
            {
                Console.WriteLine("Cartea nu va apartine sau nu a fost gasita");
                return;
            }

            bookCommandService.DeleteBook(book.Id);

            Console.WriteLine("Carte stearsa cu succes");
        }

        public void InscriereCurs()
        {
            Console.Write("Numele cursului la care doriti sa va inscrieti: ");
            string text = Console.ReadLine();

            if (text.Length == 0)
            {
                Console.WriteLine("Numele cursului trebuie introdus");
                return;
            }

            Course course = courseQueryService.GetByName(text);

            if (course == null)
            {
                Console.WriteLine("Cursul nu a fost gasit!");
                return;
            }

            try
            {
                enrolmentCommandService.CreateEnrolment(new EnrolmentCreateRequest(loggedUser.Id, course.Id, DateTime.Now));
                Console.WriteLine("Ati fost inscris cu succes la curs!");
            }
            catch (AcademyException ex) 
            {
                Console.WriteLine(ex.MesajPentruUtilizator);
            }
        }

        public void DezabonareCurs()
        {
            Console.Write("Numele cursului de la care doriti sa va dezabonati: ");
            string text = Console.ReadLine().Trim();

            Course course = courseQueryService.GetByName(text);

            if(course == null)
            {
                Console.WriteLine("Cursul nu a fost gasit!");
                return;
            }

            Guid id = enrolmentQueryService.GetEnrolmentIdByStudentAndCourseId(loggedUser.Id, course.Id);
            if (id == Guid.Empty)
            {
                Console.WriteLine("Nu sunteti inscris la acest curs!");
                return;
            }

            enrolmentCommandService.DeleteEnrolment(id);
            Console.WriteLine("Ati fost dezabonat cu succes!");
        }

        public void CursTopStudenti()
        {
            List<Course> courses = courseQueryService.GetCourses();
            Course course = null;
            Dictionary<Guid, int> d = enrolmentQueryService.GetStudentsCountPerCourse().OrderByDescending(k => k.Value).ToDictionary();

            course = courses.OrderByDescending(c => d.ContainsKey(c.Id) ? d[c.Id] : 0).FirstOrDefault();
            
            if(course == null)
            {
                Console.WriteLine("Nu exista cursuri in baza de date");
                return;
            }

            Console.WriteLine(course.Name + " " + course.Department + " cu " + d.FirstOrDefault().Value + " studenti");
        }

        public void CursuriPeDepartamente()
        {
            SortedDictionary<string, List<Course>> d = courseQueryService.GetCoursesByDepartment();
            
            foreach (string key in d.Keys) 
            {
                Console.WriteLine(key + ": " + String.Join(", ", d[key].Select(c => c.Name)));
            }
        }

        public void StudentiPeDepartamente()
        {
            SortedDictionary<string, List<Course>> d = courseQueryService.GetCoursesByDepartment();

            foreach (string key in d.Keys)
            {
                HashSet<Guid> s = [];

                foreach (Course c in d[key])
                {
                    s.UnionWith(enrolmentQueryService.GetStudentIdsForCourse(c.Id));

                }

                
                Console.WriteLine(key + ": " + s.Count + " studenti");
            }
        }
    }
}
