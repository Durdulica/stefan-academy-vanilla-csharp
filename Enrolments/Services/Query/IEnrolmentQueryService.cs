using stefan_academy_vanilla_charp.Enrolments.Models;

namespace stefan_academy_vanilla_charp.Enrolments.Services.Query
{
    public interface IEnrolmentQueryService
    {
        List<Guid> GetEnrolmentIdByStudentId(Guid studentId);

        Enrolment GetEnrolment(Guid id);

        Guid GetEnrolmentIdByStudentAndCourseId(Guid studentId, Guid courseId);

        List<Guid> GetCourseIdListByStudentId(Guid studentId);

        Dictionary<Guid, int> GetStudentsCountPerCourse();

        HashSet<Guid> GetCourseIdsForStudent(Guid studentId);

        HashSet<Guid> GetStudentIdsForCourse(Guid courseId);
    }
}
