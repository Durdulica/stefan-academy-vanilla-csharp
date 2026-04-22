using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Admins.Models
{
    public class Admin
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string firstName = string.Empty;
        public string lastName = string.Empty;
        public string email = string.Empty;
        public int salary = 0;
        public int age = 0;
        public string password = string.Empty;

        //Constructors

        public Admin()
        {
            firstName = "necunoscut";
            lastName = "necunoscut";
            Email = "necunoscut";
        }

        public Admin(string text)
        {
            string[] cuv = text.Split(',');
            Id = Guid.Parse(cuv[0]);
            FirstName = cuv[1];
            LastName = cuv[2];
            Email = cuv[3];
            Salary = Int32.Parse(cuv[4]);
            Age = Int32.Parse(cuv[5]);
            Password = cuv[6];
        }

        public Admin(string firstName, string lastName, string email, int salary, int age, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Salary = salary;
            Age = age;
            Password = password;

        }

        //Incapsulare

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Numele adminului nu poate fi gol");
                }

                string text = value.Trim();

                if (text.Length < 2 || text.Length > 30)
                {
                    throw new ArgumentException("Numele trebuie sa aiba intre 2 si 30 de caractere");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = char.IsLetter(ch) || ch == '-';
                    if (!caracterPermis)
                    {
                        throw new ArgumentException("Numele contine caractere nepermise");
                    }
                }
                firstName = text;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Prenumele adminului nu poate fi gol");
                }

                string text = value.Trim();

                if (text.Length < 2 || text.Length > 30)
                {
                    throw new ArgumentException("Prenumele trebuie sa aiba intre 2 si 30 de caractere");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = char.IsLetter(ch) || ch == '-';
                    if (!caracterPermis)
                    {
                        throw new ArgumentException("Prenumele contine caractere nepermise");
                    }
                }
                lastName = text;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Emailul nu poate fi gol");
                }

                if (value.Length < 7 || value.Length > 40)
                {
                    throw new ArgumentException("Emailul trebuie sa aiba intre 7 si 40 de caractere");
                }

                string text = value.Trim();

                if (!text.Contains("@gmail") && !text.Contains("@yahoo") && !text.Contains("@hotmail"))
                {
                    throw new ArgumentException("Email incomplet");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = char.IsLetterOrDigit(ch) || ch == '@' || ch == '.';

                    if (!caracterPermis)
                    {
                        throw new ArgumentException("Emailul contine caractere nepermise");
                    }
                }
                email = value;
            }
        }

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

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                {
                    throw new ArgumentException("Adminul este prea tanar");
                }
                age = value;
            }
        }
    }
}
