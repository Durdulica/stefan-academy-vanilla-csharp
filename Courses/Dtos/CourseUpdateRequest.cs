using stefan_academy_vanilla_charp.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Courses.Dtos
{
    public class CourseUpdateRequest : Course
    {
        public CourseUpdateRequest() : base() { }

        public CourseUpdateRequest(string name, string department) : base(name, department) { }

        public CourseUpdateRequest(string text) : base(text) { }
    }
}
