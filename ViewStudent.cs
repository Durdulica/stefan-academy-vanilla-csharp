using stefan_academy_vanilla_charp.Courses.Services;
using stefan_academy_vanilla_charp.Courses.Models;
using stefan_academy_vanilla_charp.Students.Models;
using stefan_academy_vanilla_charp.Books.Services;
using stefan_academy_vanilla_charp.Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stefan_academy_vanilla_charp.Books.Dtos;


namespace stefan_academy_vanilla_charp
{
    public class ViewStudent
    {
        //apasati tasta 1 pentru a vedea cursurile
        //apasati tasta 2 pentru a afisa cartile detinute
        //apasati tasta 3 pentru a adauga o carte
        //apasati tasta 4 pentru a modifica o carte

        private CourseService courseService = new CourseService();
        private BookService bookService = new BookService();

        private Student loggedUser = new Student("Alex", "Rosca", "rosca@gmail.com", 23);
        public void Viewer()
        {
            Console.WriteLine("Apasati tasta 1 pentru a vedea cursurile");
            Console.WriteLine("Apasati tasta 2 pentru a afisa cartile detinute");
            Console.WriteLine("Apasati tasta 3 pentru a adauga o carte");
            Console.WriteLine("Apasati tast 4 pentru a modifica o carte");

            int tasta = Int32.Parse(Console.ReadLine());
            switch (tasta)
            {
                case 1: AfisareCursuri(); break;
                case 2: AfisareCartiDetinute(); break;
                case 3: AdaugareCarte();  break;
            }
        }

        public void AfisareCursuri()
        {
            courseService.AfisareCourses();
        }

        public void AfisareCartiDetinute()
        {
            List<Book> books = bookService.GetAllStudentIdBooks(loggedUser.Id);
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
            Console.Write("Tastati Id-ul cartii pe care doriti sa o modificati: ");
            Guid Id = Guid.Parse(Console.ReadLine());

            if(bookService.FindById(Id) == null)
            {
                Console.WriteLine("Cartea nu a fost gasita");
                return;
            }

            Console.Write("Tastati Id-ul noului proprietar al cartii: ");
            Guid studentId = Guid.Parse(Console.ReadLine());

            Console.Write("Tastati noul nume al cartii: ");
            string nume = Console.ReadLine();

            try
            {
                BookUpdateRequest request = new BookUpdateRequest(studentId, nume, DateTime.Now);
                BookUpdateResponse response = bookService.UpdateBook(Id, request);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
