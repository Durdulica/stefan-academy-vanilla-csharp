using stefan_academy_vanilla_charp.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Admin : User
    {
        private int salary = 0;
        private string password = string.Empty;

        //Constructors

        public Admin() : base() { }

        public Admin(string firstName, string lastName, string email, int salary, int age, string password)
            : base(firstName, lastName, email, age)
        {
            Salary = salary;
            Password = password;
        }
        
        public Admin(string text) : base(text) {
            string[] cuv = text.Split(',');
            Salary = int.Parse(cuv[6]);
            Password = cuv[7];
        }

        //Incapsulare

        public int Salary
        {
            get { return salary; }
            set
            {
                if(value < 3500)
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
                if(value.Length < 8)
                {
                    Console.WriteLine("Parola trebuie sa aiba cel putin 8 caractere");
                }

                password = value;
            }
        }

        public override string ToText(int cnt, int size)
        {
            string list = "";
            if (cnt + 1 == size)
            {
                list += "ADMIN," + Id + "," + FirstName + "," + LastName + "," + Email
                    + "," + Age + "," + Salary + "," + Password;
            }
            else
            {
                list += "ADMIN," + Id + "," + FirstName + "," + LastName + "," + Email
                    + "," + Age + "," + Salary + "," + Password + "\n";
            }
            return list;
        }

        public override void Create(UserCreateRequest request)
        {
            base.Create(request);
            AdminCreateRequest req = request as AdminCreateRequest;
            Salary = req.Salary;
            Password = req.Password;
        }

        public override void Update(UserUpdateRequest request)
        {
            base.Update(request);
            AdminUpdateRequest req = request as AdminUpdateRequest; 
            Salary = req.Salary;
            Password = req.Password;
        }
    }
}
