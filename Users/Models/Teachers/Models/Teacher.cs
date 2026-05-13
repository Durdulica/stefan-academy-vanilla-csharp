using stefan_academy_vanilla_charp.Users.Dtos;
using stefan_academy_vanilla_charp.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Models.Teachers.Models
{
    public class Teacher : User
    {
        private int salary = 0;
        private string password;
        private int workHours = 0;

        //Constructors

        public Teacher() : base() { }

        public Teacher(string firstName, string lastName, string email, int age, int salary, string password, int workHours) 
            : base(firstName, lastName, email, age) 
        {
            Salary = salary;
            Password = password;
            WorkHours = workHours;
        }
        
        public Teacher(string text) : base(text) {
            string[] cuv = text.Split(',');
            Salary = Int32.Parse(cuv[6]);
            WorkHours = Int32.Parse(cuv[7]);
            Password = cuv[8];
        }

        //Incapsulare

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value < 4257)
                {
                    Console.WriteLine("Salariul trebuie sa fie cel putin minim pe economie");
                }
                salary = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 8)
                {
                    Console.WriteLine("Parola trebuie sa aiba cel putin 8 caractere");
                }

                password = value;
            }
        }

        public int WorkHours
        {
            get { return workHours; }
            set
            {
                if (value < 25)
                {
                    throw new ArgumentException("Profesorul nu are destule ore alocate");
                }

                if (value > 45)
                {
                    throw new ArgumentException("Profesorul are prea multe ore alocate");
                }
                workHours = value;
            }
        }

        public override string ToText(int cnt, int size)
        {
            string list = "";
            if (cnt + 1 == size)
            {
                list += "TEACHER," + Id + "," + FirstName + "," + LastName + "," + Email
                    + "," + Age + "," + Salary + "," + WorkHours + ",";
            }
            else
            {
                list += "TEACHER," + Id + "," + FirstName + "," + LastName + "," + Email
                    + "," + Age + "," + Salary + "," + WorkHours + "\n";
            }
            return list;
        }

        public override void Update(UserUpdateRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
            Age = request.Age;
            TeacherUpdateRequest req = request as TeacherUpdateRequest;
            Salary = req.Salary;
            WorkHours = req.WorkHours;
            Password = req.Password;
        }
    }
}
