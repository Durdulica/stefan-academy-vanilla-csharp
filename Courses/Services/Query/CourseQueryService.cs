using stefan_academy_vanilla_charp.Courses.Models;
using stefan_academy_vanilla_charp.Courses.Repositories;

namespace stefan_academy_vanilla_charp.Courses.Services.Query
{
    public class CourseQueryService : ICourseQueryService
    {
        private readonly ICourseRepository repository;

        public CourseQueryService(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public Course GetCourse(Guid id) => repository.FindById(id);

        public List<Course> GetCourses() => repository.Courses();

        public Course GetByName(string name) => repository.FindByName(name);

        public List<Course> GetCourseListByCourseId(List<Guid> coursesId) => repository.GetCourseListByCourseId(coursesId);

        public SortedDictionary<string, List<Course>> GetCoursesByDepartment() => repository.CoursesByDepartment();
    }
}
