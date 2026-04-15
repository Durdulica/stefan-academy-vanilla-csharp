using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Student.Models
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private int age;

        public Student()
        {
            FirstName = "Necunoscut";
            LastName = "Necunoscut";
            Email = "Necunoscut";
            age = -1;
        }
        public Student(string firstName, string lastName, string email, int age) { 
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }

        public Student(string text)
        {
            string[] cuv = text.Split(',');
            FirstName = cuv[0];
            LastName = cuv[1];
            Email = cuv[2];
            Age = Int32.Parse(cuv[3]);
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Numele studentului nu poate fi gol");
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
                    throw new ArgumentException("Prenumele studentului nu poate fi gol");
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

                if(!text.Contains("@gmail") && !text.Contains("@yahoo") && !text.Contains("@hotmail"))
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

        public int Age
        {
            get { return age; }
            set
            {
                if(value < 18)
                {
                    throw new ArgumentException("Studentul este prea tanar");
                }
                age = value;
            }
        }
    }
}
