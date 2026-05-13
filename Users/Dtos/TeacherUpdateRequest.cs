using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public class TeacherUpdateRequest : UserUpdateRequest
    {
        private int salary = 0;
        private int workHours = 0;
        private string password;

        //Constructors

        public TeacherUpdateRequest() : base() { }

        public TeacherUpdateRequest(string firstName, string lastName, string email, int age, int salary, int workHours, string password)
            : base(firstName, lastName, email, age)
        {
            Salary = salary;
            WorkHours = workHours;
            Password = password;
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
    }
}
