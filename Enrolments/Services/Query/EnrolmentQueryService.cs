using stefan_academy_vanilla_charp.Enrolments.Models;
using stefan_academy_vanilla_charp.Enrolments.Repositories;

namespace stefan_academy_vanilla_charp.Enrolments.Services.Query
{
    public class EnrolmentQueryService : IEnrolmentQueryService
    {
        private readonly IEnrolmentRepository repository;

        public EnrolmentQueryService(IEnrolmentRepository repository)
        {
            this.repository = repository;
        }

        public List<Guid> GetEnrolmentIdByStudentId(Guid studentId) => repository.CourseIdByStudentId(studentId);

        public Enrolment GetEnrolment(Guid id) => repository.FindById(id);

        public Guid GetEnrolmentIdByStudentAndCourseId(Guid studentId, Guid courseId) => repository.EnrolmentIdByStudentAndCourseId(studentId, courseId);

        public List<Guid> GetCourseIdListByStudentId(Guid studentId) => repository.CourseIdByStudentId(studentId);

        public Dictionary<Guid, int> GetStudentsCountPerCourse() => repository.StudentsCountPerCourse();

        public HashSet<Guid> GetCourseIdsForStudent(Guid studentId) => repository.CourseIdsForStudent(studentId);

        public HashSet<Guid> GetStudentIdsForCourse(Guid courseId) => repository.StudentIdsForCourse(courseId);
    }
}
