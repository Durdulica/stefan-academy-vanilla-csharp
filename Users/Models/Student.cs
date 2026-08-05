using stefan_academy_vanilla_charp.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Student : User
    {
        public Student() : base() { }

        public Student(string firstName, string lastName, string email, int age) 
            : base(firstName, lastName, email, age) { }

        public Student(string text) : base(text) { }

        public override string ToText(int cnt, int size)
        {
            string list = "";
            if (cnt + 1 == size)
            {
                list += "STUDENT," + Id + "," + FirstName + "," + LastName + "," + Email + "," + Age;
            }
            else
            {
                list += "STUDENT," + Id + "," + FirstName + "," + LastName + "," + Email + "," + Age + "\n";
            }
            return list;
        }

        public override void Create(UserCreateRequest request)
        {
            base.Create(request);
        }

        public override void Update(UserUpdateRequest request)
        {
            base.Update(request);
        }
    }
}
