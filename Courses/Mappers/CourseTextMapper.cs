using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Courses.Models;

namespace stefan_academy_vanilla_charp.Courses.Mappers
{
    public class CourseTextMapper : ITextMapper<Course>
    {
        public string ToText(Course item)
        {
            return item.Id + "," + item.Name + "," + item.Department;
        }

        public Course FromText(string text)
        {
            string[] cuv = text.Split(',');

            return new Course(Guid.Parse(cuv[0]), cuv[1], cuv[2]);
        }
    }
}