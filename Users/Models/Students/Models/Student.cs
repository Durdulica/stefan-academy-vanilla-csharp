using stefan_academy_vanilla_charp.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Models.Students.Models
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
    }
}
