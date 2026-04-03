using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Student.Dtos
{
    internal class StudentUpdateResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

    }
}
