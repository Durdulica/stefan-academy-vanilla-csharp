using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Enrolments.Models;
using System.Globalization;

namespace stefan_academy_vanilla_charp.Enrolments.Mappers
{
    public class EnrolmentTextMapper : ITextMapper<Enrolment>
    {
        public string ToText(Enrolment item)
        {
            return item.Id + "," + item.StudentId + "," + item.CourseId + "," + item.CreatedAt.ToString("yyyy-MM-dd");
        }

        public Enrolment FromText(string text) 
        {
            string[] cuv = text.Split(',');

            return new Enrolment(Guid.Parse(cuv[0]), Guid.Parse(cuv[1]), Guid.Parse(cuv[2]),
                DateTime.ParseExact(cuv[3], "yyyy-MM-dd",CultureInfo.InvariantCulture));
        }
    }
}