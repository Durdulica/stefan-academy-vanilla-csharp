using stefan_academy_vanilla_charp.Courses.Models;

namespace stefan_academy_vanilla_charp.Courses.Repositories
{
    public interface ICourseRepository
    {
        Course FindById(Guid id);

        Course FindByName(string name);

        SortedDictionary<string, List<Course>> CoursesByDepartment();

        List<Course> GetCourseListByCourseId(List<Guid> coursesId);

        List<Course> Courses();

        void Add(Course course);
        
        void Update(Course course);

        void Remove(Course course);
    }
}
