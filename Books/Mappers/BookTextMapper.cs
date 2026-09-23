using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Books.Mappers
{
    public class BookTextMapper : ITextMapper<Book>
    {
        public string Name { get; } = nameof(BookTextMapper);

        public string ToText(Book item)
        {
            return item.Id + "," + item.StudentId + "," + item.BookName + "," + item.CreatedAt.ToString("yyyy-MM-dd");
        }

        public Book FromText(string text)
        {
            string[] cuv = text.Split(',');
            Send("Book created " + cuv[2] + " succesfully");
            return new Book(Guid.Parse(cuv[0]), Guid.Parse(cuv[1]), cuv[2], DateTime.Parse(cuv[3]));
        }

        public void Send(string message)
        {
            Console.WriteLine(Name + ": " + message);
        }
    }
}
