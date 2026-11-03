using stefan_academy_vanilla_charp.Courses.Dtos;

namespace stefan_academy_vanilla_charp.Courses.Services.Command
{
    public interface ICourseCommandService
    {
        CourseCreateResponse CreateCourse(CourseCreateRequest request);

        CourseUpdateResponse UpdateCourse(Guid id, CourseUpdateRequest request);

        void DeleteCourse(Guid id);
    }
}
