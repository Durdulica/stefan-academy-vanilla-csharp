using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Common.Exceptions;

namespace stefan_academy_vanilla_charp.Users.Models
{
    public  abstract class User : IEntity 
    {
        public Guid Id { get; private set; }
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private int age = 0;

        //Constructors

        public User(Guid id, string firstName, string lastName, string email, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }

        public User(string firstName, string lastName, string email, int age) 
            : this(Guid.NewGuid(), firstName, lastName, email, age) { }
        
        //Incapsulare

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ValidationException("Numele", "uerului nu poate fi gol");
                }

                string text = value.Trim();

                if (text.Length < 2 || text.Length > 30)
                {
                    throw new ValidationException("Numele", "trebuie sa aiba intre 2 si 30 de caractere");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = char.IsLetter(ch) || ch == '-';
                    if (!caracterPermis)
                    {
                        throw new ValidationException("Numele", "contine caractere nepermise");
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
                    throw new ValidationException("Prenumele", "userului nu poate fi gol");
                }

                string text = value.Trim();

                if (text.Length < 2 || text.Length > 30)
                {
                    throw new ValidationException("Prenumele", "trebuie sa aiba intre 2 si 30 de caractere");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = char.IsLetter(ch) || ch == '-';
                    if (!caracterPermis)
                    {
                        throw new ValidationException("Prenumele", "contine caractere nepermise");
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
                string text = value.Trim();

                if (text.Length == 0)
                {
                    throw new ValidationException("Emailul", "nu poate fi gol");
                }

                if (text.Length < 7 || text.Length > 40)
                {
                    throw new ValidationException("Emailul", "trebuie sa aiba intre 7 si 40 de caractere");
                }

                

                if (!text.Contains("@gmail") && !text.Contains("@yahoo") && !text.Contains("@hotmail"))
                {
                    throw new ValidationException("Email", "incomplet");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = char.IsLetterOrDigit(ch) || ch == '@' || ch == '.';

                    if (!caracterPermis)
                    {
                        throw new ValidationException("Emailul", "contine caractere nepermise");
                    }
                }
                email = text;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                {
                    throw new ValidationException("Userul", "este prea tanar");
                }
                age = value;
            }
        }
    }
}
