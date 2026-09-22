namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Teacher : User
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
                    throw new ArgumentException("Salariul trebuie sa fie cel putin minim pe economie");
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
                    throw new ArgumentException("Parola trebuie sa aiba cel putin 8 caractere");
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
