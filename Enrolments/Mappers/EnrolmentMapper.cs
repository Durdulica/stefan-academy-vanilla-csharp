using stefan_academy_vanilla_charp.Enrolments.Dtos;
using stefan_academy_vanilla_charp.Enrolments.Models;

namespace stefan_academy_vanilla_charp.Enrolments.Mappers
{
    public static class EnrolmentMapper
    {
        public static Enrolment ToEnrolment(EnrolmentCreateRequest request)
        {
            return new Enrolment(request.StudentId, request.CourseId, request.CreatedAt);
        }

        public static void ApplyUpdate(Enrolment enrolment, EnrolmentUpdateRequest request)
        {
            enrolment.StudentId = request.StudentId;
            enrolment.CourseId = request.CourseId;
        }

        public static EnrolmentCreateResponse ToCreateResponse(Enrolment enrolment)
        {
            return new EnrolmentCreateResponse(enrolment.Id, enrolment.StudentId, enrolment.CourseId, enrolment.CreatedAt);
        }

        public static EnrolmentUpdateResponse ToUpdateResponse(Enrolment enrolment)
        {
            return new EnrolmentUpdateResponse(enrolment.Id, enrolment.StudentId, enrolment.CourseId);
        }
    }
}