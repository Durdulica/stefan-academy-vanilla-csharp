namespace stefan_academy_vanilla_charp.Enrolments.Dtos
{
    public record EnrolmentCreateResponse(Guid Id, Guid StudentId, Guid CourseId, DateTime CreatedAt);
}
