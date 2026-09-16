using stefan_academy_vanilla_charp.Courses.Dtos;
using stefan_academy_vanilla_charp.Courses.Models;

namespace stefan_academy_vanilla_charp.Courses.Mappers
{
    public class CourseMapper
    {
        public static Course ToCourse(CourseCreateRequest request)
        {
            return new Course(request.Name, request.Department);
        }

        public static void ApplyUpdate(Course course, CourseUpdateRequest request) 
        {
            course.Name = request.Name;
            course.Department = request.Department;
        }

        public static CourseCreateResponse ToCreateResponse(Course course)
        {
            return new CourseCreateResponse(course.Id, course.Name, course.Department);
        }

        public static CourseUpdateResponse ToUpdateResponse(Course course)
        {
            return new CourseUpdateResponse(course.Id, course.Name, course.Department);
        }
    }
}