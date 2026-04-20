using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Enrolments.Models
{
    public class Enrolment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid StudentId { get; set; } = Guid.Empty;
        public Guid CourseId { get; set; } = Guid.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Enrolment(string text)
        {
            string[] cuv = text.Split(',');
            Id = Guid.Parse(cuv[0]);
            StudentId = Guid.Parse(cuv[1]);
            CourseId = Guid.Parse(cuv[2]);
            CreatedAt = DateTime.Parse(cuv[3]);
        }

        public Enrolment(Guid studentId, Guid courseId, DateTime createdAt) {
            StudentId = studentId;
            CourseId = courseId;
        }


    }
}
