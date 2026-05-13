using stefan_academy_vanilla_charp.Users.Models.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public class AdminUpdateRequest : UserUpdateRequest
    {
        private int salary = 0;
        private string password;

        public AdminUpdateRequest() : base() { }

        public AdminUpdateRequest(string firstName, string lastName, string email, int salary, int age, string password)
            : base(firstName,lastName, email, age) {
            Salary = salary;
            Password = password;
        }

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
