using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Courses.Models;

namespace stefan_academy_vanilla_charp.Courses.Mappers
{
    public class CourseTextMapper : ITextMapper<Course>
    {
        public string Name { get; } = nameof(CourseTextMapper);

        public string ToText(Course item)
        {
            return item.Id + "," + item.Name + "," + item.Department;
        }

        public Course FromText(string text)
        {
            string[] cuv = text.Split(',');
            Send("Course " + cuv[1] + "created succesfully");
            return new Course(Guid.Parse(cuv[0]), cuv[1], cuv[2]);
        }

        public void Send(string message)
        {
            Console.WriteLine(Name + " " + message);
        }
    }
}
