using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Enrolments.Dtos
{
    public class EnrolmentCreateResponse
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
