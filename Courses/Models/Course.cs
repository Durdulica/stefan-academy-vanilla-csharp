using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Courses.Models
{
    public class Course : IEntity
    {
        public Guid Id { get; private set; }
        private string name = string.Empty;
        private string department = string.Empty;

        public Course(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public Course(Guid id, string name, string department) : this(name, department)
        {
            Id = id;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("Numele cursului nu poate fi gol");
                }

                string text = value.Trim();
                if (text.Length < 2 || text.Length > 30)
                {
                    throw new ArgumentException("Numele cursului trebuie sa aiba intre 2 si 30 de caractere");
                }

                foreach(char ch in  text )
                {
                    bool caracterPermis = Char.IsLetterOrDigit(ch) || ch == ' ';
                    if (!caracterPermis)
                    {
                        throw new ArgumentException("Numele cursului contine caractere nepermise");
                    }
                }
                name = text;
            }
        }

        public string Department
        {
            get{ return department; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Departamentul cursului nu poate fi gol");
                }

                string text = value.Trim();
                if (text.Length < 2 || text.Length > 30)
                {
                    throw new ArgumentException("Departamentul cursului trebuie sa aiba intre 2 si 30 de caractere");
                }

                foreach (char ch in text)
                {
                    bool caracterPermis = Char.IsLetterOrDigit(ch);
                    if (!caracterPermis)
                    {
                        throw new ArgumentException("Departamentul cursului contine caractere nepermise");
                    }
                }
                department = text;
            }
        }
    }
}