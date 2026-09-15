namespace stefan_academy_vanilla_charp.Enrolments.Dtos
{
    public record EnrolmentCreateRequest(Guid StudentId, Guid CourseId, DateTime CreatedAt);
}