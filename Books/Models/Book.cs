using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Books.Models
{
    public class Book : IEntity
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; set; } = Guid.Empty;
        private string bookName = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Book(Guid id, Guid studentId, string bookName, DateTime createdAt)
        {
            Id = id;
            StudentId = studentId;
            BookName = bookName;
            CreatedAt = createdAt;
        }

        public Book(Guid studentId, string bookName, DateTime createdAt)
            : this(Guid.NewGuid(), studentId, bookName, createdAt) { }

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
    }
}
