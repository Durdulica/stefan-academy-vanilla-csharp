using stefan_academy_vanilla_charp.Enrolments.Models;

namespace stefan_academy_vanilla_charp.Enrolments.Repositories
{
    public interface IEnrolmentRepository
    {
        Enrolment FindById(Guid id);

        List<Guid> GetEnrolmentIdByStudentId(Guid studentId);

        Guid GetEnrolmentIdByStudentAndCourseId(Guid studentId, Guid courseId);

        List<Guid> GetCourseIdListByStudentId(Guid studentId);

        Dictionary<Guid, int> StudentsCountPerCourse();

        HashSet<Guid> CourseIdsForStudent(Guid studentId);

        void Add(Enrolment enrolment);

        void Update(Enrolment enrolment);

        void Remove(Enrolment enrolment);
    }
}
