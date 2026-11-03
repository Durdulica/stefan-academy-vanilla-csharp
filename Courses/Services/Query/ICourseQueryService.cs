using stefan_academy_vanilla_charp.Courses.Models;

namespace stefan_academy_vanilla_charp.Courses.Services.Query
{
    public interface ICourseQueryService
    {
        Course GetCourse(Guid id);

        List<Course> GetCourses();

        Course GetByName(string name);

        List<Course> GetCourseListByCourseId(List<Guid> coursesId);

        SortedDictionary<string, List<Course>> GetCoursesByDepartment();


    }
}
