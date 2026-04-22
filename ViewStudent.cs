using stefan_academy_vanilla_charp.Courses.Services;
using stefan_academy_vanilla_charp.Courses.Models;
using stefan_academy_vanilla_charp.Students.Models;
using stefan_academy_vanilla_charp.Books.Services;
using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Books.Dtos;
using stefan_academy_vanilla_charp.Enrolments.Models;
using stefan_academy_vanilla_charp.Enrolments.Services;

namespace stefan_academy_vanilla_charp
{
    public class ViewStudent
    {
        private CourseService courseService = new CourseService();
        private BookService bookService = new BookService();
        private EnrolmentService enrolmentService = new EnrolmentService();

        private Student loggedUser = new Student("Alex", "Rosca", "rosca@gmail.com", 23);
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
                tasta = Int32.Parse(Console.ReadLine());

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
            while (tasta != 0);
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

                tasta = Int32.Parse(Console.ReadLine());
                switch (tasta)
                {
                    case 0: break;
                    case 1: AfisareCartiDetinute(); break;
                    case 2: AdaugareCarte(); break;
                    case 3: ModificareCarte(); break;
                    case 4: StergereCarte(); break;
                    default: InputGresit(); break;
                }
            }while(tasta != 0);
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

                tasta = Int32.Parse(Console.ReadLine());
                switch (tasta)
                {
                    case 0: break;
                    case 1: AfisareCursuri(); break;
                    case 2: InscriereCurs(); break;
                    case 3: DezabonareCurs(); break;
                    default: InputGresit(); break;
                }
            } while (tasta != 0);
        }

        public void Statistici()
        {
            int tasta;
            do
            {
                Console.WriteLine("Apasati tasta 0 pentru a va intoarce");
                Console.WriteLine("Apasati tasta 1 pentru a vedea cursul cu cei mai multi elevi");
                tasta = Int32.Parse(Console.ReadLine());

                switch (tasta)
                {
                    case 0: return;
                    case 1: CursTopStudenti(); break;
                    default: InputGresit(); break;
                }
            } while (tasta != 0);
        }

        //Functii

        public void InputGresit()
        {
            Console.WriteLine("Ati introdus un caracter nepermis!");
        }

        public void AfisareCursuri()
        {
            List<Course> courses = courseService.GetCourseListByEnrolmentId(enrolmentService.GetEnrolmentIdByStudentId(loggedUser.Id));
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

        public void AfisareCartiDetinute()
        {
            List<Book> books = bookService.GetBooksByStudentId(loggedUser.Id);
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
                BookCreateResponse response = bookService.CreateBook(request);
                if (response != null)
                {
                    Console.WriteLine("Cartea " + response.BookName + " adaugata cu succes la data de " + response.CreatedAt.ToString("dd-MM-yyyy"));
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void ModificareCarte()
        {
            Console.Write("Tastati numele cartii pe care doriti sa o modificati: ");
            string text = Console.ReadLine();
            Book book = bookService.GetBook(loggedUser.Id, text);

            if (book == null)
            {
                Console.WriteLine("Cartea nu va apartine sau nu a fost gasita");
                return;
            }

            Console.Write("Tastati noul nume al cartii: ");
            string nume = Console.ReadLine();

            try
            {
                BookUpdateRequest request = new BookUpdateRequest(book.Id, nume, DateTime.Now);
                BookUpdateResponse response = bookService.UpdateBook(book.Id, request);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void StergereCarte()
        {
            Console.Write("Tastati numele cartii pe care doriti sa o stergeti: ");
            string text = Console.ReadLine();
            Book book = bookService.GetBook(loggedUser.Id, text);

            if (book == null)
            {
                Console.WriteLine("Cartea nu va apartine sau nu a fost gasita");
                return;
            }

            bookService.DeleteBook(book.Id);

            Console.WriteLine("Carte stearsa cu succes");
        }

        public void InscriereCurs()
        {
            Console.Write("Numele cursului la care doriti sa va inscrieti: ");
            string text = Console.ReadLine();

            Course course = courseService.FindByName(text);
            if (course == null)
            {
                Console.WriteLine("Cursul nu a fost gasit!");
                return;
            }

            if(enrolmentService.GetEnrolmentIdByStudentAndCourseId(loggedUser.Id,course.Id) != Guid.Empty)
            {
                Console.WriteLine("Sunteti deja inscris la acest curs!");
                return;
            }

            enrolmentService.Enrolments.Add(new Enrolment(loggedUser.Id, course.Id, DateTime.Now));
            Console.WriteLine("Ati fost inscris cu succes la curs!");
        }

        public void DezabonareCurs()
        {
            Console.Write("Numele cursului de la care doriti sa va dezabonati");
            string text = Console.ReadLine();

            Course course = courseService.FindByName(text);

            if(course == null)
            {
                Console.WriteLine("Cursul nu a fost gasit!");
                return;
            }

            Guid id = enrolmentService.GetEnrolmentIdByStudentAndCourseId(loggedUser.Id, course.Id);
            if (id == Guid.Empty)
            {
                Console.WriteLine("Nu sunteti inscris la acest curs!");
                return;
            }

            enrolmentService.DeleteEnrolment(id);
            Console.WriteLine("Ati fost dezabonat cu succes!");
        }

        public void CursTopStudenti()
        {
            List<Course> courses = courseService.Courses;
            Course course = null;
            int index = -1;

            foreach (Course c in courses)
            {
                int aux = enrolmentService.StudentsCountForCourseId(c.Id);
                Console.WriteLine(aux);
                if(aux > index)
                {
                    index = aux;
                    course = c;
                }
            }

            if(course == null)
            {
                Console.WriteLine("Nu exista cursuri in baza de date");
                return;
            }

            Console.WriteLine(course.Name + " " + course.Department + " cu " + index + " studenti");
        }
    }
}