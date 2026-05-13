using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public class AdminCreateRequest : UserCreateRequest
    {
        private int salary = 0;
        private string password;

        //Constructors

        public AdminCreateRequest() : base() { }

        public AdminCreateRequest(string firstName, string lastName, string email, int salary, int age, string password)
            : base(firstName, lastName, email, age) {
            Salary = salary;
            Password = password;
        }

        //Incapsulare

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value < 3500)
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
    }
}
