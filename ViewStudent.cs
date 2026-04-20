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
        //apasati tasta 0 pentru a iesi
        //apasati tasta 1 pentru a vedea cursurile
        //apasati tasta 2 pentru a afisa cartile detinute
        //apasati tasta 3 pentru a adauga o carte
        //apasati tasta 4 pentru a modifica o carte
        //apasati tasta 5 pentru a sterge o carte

        private CourseService courseService = new CourseService();
        private BookService bookService = new BookService();
        private EnrolmentService enrolmentService = new EnrolmentService();

        private Student loggedUser = new Student("Alex", "Rosca", "rosca@gmail.com", 23);
        public void Viewer()
        {
            int tasta;
            do
            {
                Console.WriteLine("Apasati tasta 0 pentru a iesi");
                Console.WriteLine("Apasati tasta 1 pentru a vedea cursurile");
                Console.WriteLine("Apasati tasta 2 pentru a afisa cartile detinute");
                Console.WriteLine("Apasati tasta 3 pentru a adauga o carte");
                Console.WriteLine("Apasati tasta 4 pentru a modifica o carte");
                Console.WriteLine("Apasati tasta 5 pentru a sterge o carte");

                tasta = Int32.Parse(Console.ReadLine());

                switch (tasta)
                {
                    case 0: return;
                    case 1: AfisareCursuri(); break;
                    case 2: AfisareCartiDetinute(); break;
                    case 3: AdaugareCarte(); break;
                    case 4: ModificareCarte(); break;
                    case 5: StergereCarte(); break;
                }
                //Console.Clear();
            }
            while (tasta != 0);
        }

        public void AfisareCursuri()
        {
            List<Course> courses = courseService.GetCourseListByEnrolmentId(enrolmentService.GetEnrolmentIdByStudentId(loggedUser.Id));
            foreach (Course c in courses)
            {
                Console.WriteLine("nume: " + c.Name + ", departament: " + c.Department);
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
    }
}
