using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stefan_academy_vanilla_charp.Users.Dtos;

namespace stefan_academy_vanilla_charp.Users.Models.Students.Dtos
{
    public class StudentCreateRequest : UserCreateRequest
    {
        public StudentCreateRequest() : base() { }
        
        public StudentCreateRequest(string firstName, string lastName, string email, int age)
            : base(firstName, lastName, email, age) { }
    }
}
