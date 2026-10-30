using stefan_academy_vanilla_charp.Common.Exceptions;
using stefan_academy_vanilla_charp.Courses.Dtos;
using stefan_academy_vanilla_charp.Courses.Mappers;
using stefan_academy_vanilla_charp.Courses.Models;
using stefan_academy_vanilla_charp.Courses.Repositories;

namespace stefan_academy_vanilla_charp.Courses.Services
{
    public class CourseService
    {
        private readonly CourseRepository repository;

        public CourseService(CourseRepository repository)
        {
            this.repository = repository;
        }

        public Course GetCourse(Guid id) => repository.FindById(id);

        public List<Course> GetCourses() => repository.Courses();

        //CRUD

        public Course GetByName(string name) => repository.FindByName(name);

        public List<Course> GetCourseListByCourseId(List<Guid> coursesId) => repository.GetCourseListByCourseId(coursesId);

        public SortedDictionary<string, List<Course>> GetCoursesByDepartment() => repository.CoursesByDepartment();

        public CourseCreateResponse CreateCourse(CourseCreateRequest request)
        {
            Course newCourse = CourseMapper.ToCourse(request);

            if (repository.FindByName(newCourse.Name) != null)
            {
                throw new DuplicateException("Cursul", newCourse.Name);
            }

            repository.Add(newCourse);

            return CourseMapper.ToCreateResponse(newCourse);
        }

        public CourseUpdateResponse UpdateCourse(Guid id, CourseUpdateRequest request)
        {
            Course course = repository.FindById(id);
            if (course == null)
            {
                throw new NotFoundException("Cursul", id.ToString());
            }

            CourseMapper.ApplyUpdate(course, request);
            repository.Update(course);
            return CourseMapper.ToUpdateResponse(course);
        }

        public void DeleteCourse(Guid id)
        {
            Course course = repository.FindById(id);

            if (course == null)
            {
                throw new NotFoundException("Cursul", id.ToString());
            }

            repository.Remove(course);
        }
    }
}
