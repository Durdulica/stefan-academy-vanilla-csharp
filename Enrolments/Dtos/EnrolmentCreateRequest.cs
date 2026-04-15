using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Enrolments.Dtos
{
    public class EnrolmentCreateRequest
    {
        public Guid StudentId { get; set; } = Guid.Empty;
        public Guid CourseId { get; set; } = Guid.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public EnrolmentCreateRequest(string text)
        {
            string[] cuv = text.Split(',');
            StudentId = Guid.Parse(cuv[0]);
            CourseId = Guid.Parse(cuv[1]);
            CreatedAt = DateTime.Parse(cuv[2]);
        }

        public EnrolmentCreateRequest(Guid studentId, Guid courseId, DateTime createdAt)
        {
            StudentId = studentId;
            CourseId = courseId;

        }
    }
}
