using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Books.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private Guid studentId = Guid.Empty;
        private string bookName = string.Empty;
        private DateTime createdAt;

        public Book(Guid studentId, string bookName, DateTime createdAt)
        {
            StudentId = studentId;
            BookName = bookName;
            CreatedAt = createdAt;
        }
        public Guid StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public string BookName
        {
            get { return bookName; }
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("Numele cartii nu poate fi gol");
                }

                string text = value.Trim();

                if (text.Length < 2 || text.Length > 30)
                {
                    throw new ArgumentException("Numele cartii trebuie sa aiba intre 2 si 30 de caractere");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = char.IsLetterOrDigit(ch);
                    if (!caracterPermis)
                    {
                        throw new ArgumentException("Numele contine caractere nepermise");
                    }
                }
                bookName = text;
            }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }
    }
}
