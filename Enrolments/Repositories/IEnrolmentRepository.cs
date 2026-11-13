using stefan_academy_vanilla_charp.Enrolments.Models;

namespace stefan_academy_vanilla_charp.Enrolments.Repositories
{
    public interface IEnrolmentRepository
    {
        Enrolment FindById(Guid id);

        List<Guid> EnrolmentListByStudentId(Guid studentId);

        Guid EnrolmentIdByStudentAndCourseId(Guid studentId, Guid courseId);

        List<Guid> CourseIdByStudentId(Guid studentId);

        Dictionary<Guid, int> StudentsCountPerCourse();

        HashSet<Guid> CourseIdsForStudent(Guid studentId);

        HashSet<Guid> StudentIdsForCourse(Guid courseId);

        void Add(Enrolment enrolment);

        void Update(Enrolment enrolment);

        void Remove(Enrolment enrolment);
    }
}
