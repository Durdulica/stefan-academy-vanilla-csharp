using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Dtos;

namespace stefan_academy_vanilla_charp.Users.Models
{
    public class User : IEntity
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

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                {
                    throw new ArgumentException("Studentul este prea tanar");
                }
                age = value;
            }
        }

        /*public virtual string ToText(int cnt, int size)
        {
            string list = "";
            if (cnt + 1 == size)
            {
                list += "USER," + Id + "," + FirstName + "," + LastName + "," + Email + "," + Age;
            }
            else
            {
                list += "USER," + Id + "," + FirstName + "," + LastName + "," + Email + "," + Age + "\n";
            }
            return list;
        }

        public virtual void Create(UserCreateRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
            Age = request.Age;
        }

        public virtual void Update(UserUpdateRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
        }*/
    }
}
