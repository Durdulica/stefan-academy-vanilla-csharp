using stefan_academy_vanilla_charp.Common;
using System.Collections.Generic;

namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Teacher : User, ITextMapper<Teacher>
    {
        private int salary = 0;
        private string password;
        private int workHours = 0;

        //Constructors

        public Teacher(string firstName, string lastName, string email, int age, int salary, int workHours, string password) 
            : base(firstName, lastName, email, age) 
        {
            Salary = salary;
            Password = password;
            WorkHours = workHours;
        }

        public Teacher(Guid id, string firstName, string lastName, string email, int age, int salary, int workHours, string password)
            : base(id, firstName, lastName, email, age)
        {
            Salary = salary;
            Password = password;
            WorkHours = workHours;
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

        public string ToText(Teacher item)
        {
            return "TEACHER," + Id + "," + FirstName + "," + LastName + "," + Email
                    + "," + Age + "," + Salary + "," + WorkHours + "," + Password;
        }

        public Teacher FromText(string text)
        {
            string []cuv = text.Split(',');

            return new Teacher(Guid.Parse(cuv[0]), cuv[1], cuv[2], cuv[3], Int32.Parse(cuv[4]), Int32.Parse(cuv[5]), cuv[6]);
        }
    }
}