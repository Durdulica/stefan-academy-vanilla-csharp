using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Enrolments.Models
{
    public class Enrolment : IEntity
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; set; } = Guid.Empty;
        public Guid CourseId { get; set; } = Guid.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Enrolment(Guid id, Guid studentId, Guid courseId, DateTime createdAt) {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
            CreatedAt = createdAt;
        }

        public Enrolment(Guid studentId, Guid courseId, DateTime createdAt) 
            : this(Guid.NewGuid(), studentId, courseId, createdAt) { }
        }
}
