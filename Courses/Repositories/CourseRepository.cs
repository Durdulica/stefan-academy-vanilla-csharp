using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Courses.Mappers;
using stefan_academy_vanilla_charp.Courses.Models;

namespace stefan_academy_vanilla_charp.Courses.Repositories
{
    public class CourseRepository : Repository<Course>
    {
        public CourseRepository() : base(new CourseTextMapper(), Path.Combine("..", "..", "..", "Data", "courses.txt")) { }

        public List<Course> Courses()
        {
            return Items;
        }

        public List<Course> GetCourseListByCourseId(List<Guid> coursesId)
        {
            List<Course> studentCourses = new();

            foreach (Guid id in coursesId)
            {
                Course c = FindById(id);
                if (c != null) studentCourses.Add(c);
            }

            return studentCourses;
        }

        public Course FindByName(string name)
        {
            foreach (Course c in Items)
            {
                if (c.Name == name)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
