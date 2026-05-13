using stefan_academy_vanilla_charp.Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Books.Dtos
{
    public class BookCreateRequest : Book
    {

        public BookCreateRequest(Guid studentId, string bookName, DateTime createdAt)
            : base(studentId, bookName, createdAt) { }

        public BookCreateRequest(string text) : base(text) { }
    }
}
