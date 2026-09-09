using stefan_academy_vanilla_charp.Books.Models;
using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Books.Mappers
{
    public class BookTextMapper : ITextMapper<Book>
    {
        public string ToText(Book item)
        {
            return item.Id + "," + item.StudentId + "," + item.BookName + "," + item.CreatedAt.ToString("yyyy-MM-dd");
        }

        public Book FromText(string text)
        {
            string[] cuv = text.Split(',');

            return new Book(Guid.Parse(cuv[0]), Guid.Parse(cuv[1]), cuv[2], DateTime.Parse(cuv[3]));
        }
    }
}
