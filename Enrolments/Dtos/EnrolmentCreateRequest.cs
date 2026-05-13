using stefan_academy_vanilla_charp.Enrolments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Enrolments.Dtos
{
    public class EnrolmentCreateRequest : Enrolment
    {
        public EnrolmentCreateRequest(string text) : base(text) { }

        public EnrolmentCreateRequest(Guid studentId, Guid courseId, DateTime createdAt)
            : base(studentId, courseId, createdAt) { }
    }
}
