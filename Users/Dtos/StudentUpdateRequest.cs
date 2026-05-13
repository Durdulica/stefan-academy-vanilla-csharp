using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public class StudentUpdateRequest : UserUpdateRequest
    {
        public StudentUpdateRequest() : base() { }

        public StudentUpdateRequest(string firstName, string lastName, string email, int age)
            : base(firstName, lastName, email, age) { }
    }
}
