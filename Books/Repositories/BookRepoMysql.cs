using stefan_academy_vanilla_charp.Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Books.Repositories
{
    internal class BookRepoMysql:IBookRepository
    {
        private static IBookRepository instance;

        public static IBookRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine("acum creez");
                    instance = new BookRepoMysql();
                }

                Console.WriteLine("acum doar accesez");
                return instance;
            }
        }

        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Book FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Book FindByStudentAndName(Guid studentId, string bookName)
        {
            throw new NotImplementedException();
        }

        public List<Book> FindByStudentId(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Book book)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
