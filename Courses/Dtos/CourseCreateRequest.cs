using stefan_academy_vanilla_charp.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Courses.Dtos
{
    public class CourseCreateRequest : Course
    {
        public CourseCreateRequest() : base() { }

        public CourseCreateRequest(string name, string department) : base(name, department) { }

        public CourseCreateRequest(string text) : base(text) { }
    }
}
