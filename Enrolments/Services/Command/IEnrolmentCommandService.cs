using stefan_academy_vanilla_charp.Enrolments.Dtos;

namespace stefan_academy_vanilla_charp.Enrolments.Services.Command
{
    public interface IEnrolmentCommandService
    {
        EnrolmentCreateResponse CreateEnrolment(EnrolmentCreateRequest request);

        EnrolmentUpdateResponse UpdateEnrolment(Guid id, EnrolmentUpdateRequest request);

        void DeleteEnrolment(Guid id);
    }
}
