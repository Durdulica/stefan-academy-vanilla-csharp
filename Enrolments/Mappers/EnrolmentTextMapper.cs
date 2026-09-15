using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Enrolments.Models;

namespace stefan_academy_vanilla_charp.Enrolments.Mappers
{
    public class EnrolmentTextMapper : ITextMapper<Enrolment>
    {
        public string ToText(Enrolment item)
        {
            return item.Id + "," + item.StudentId + "," + item.CourseId + "," + item.CreatedAt;
        }

        public Enrolment FromText(string text) 
        {
            string[] cuv = text.Split(',');

            return new Enrolment(Guid.Parse(cuv[1]), Guid.Parse(cuv[2]), Guid.Parse(cuv[3]), DateTime.Parse(cuv[4]));
        }
    }
}