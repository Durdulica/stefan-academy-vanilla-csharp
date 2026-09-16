namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Admin : User
    {
        private int salary = 0;
        private string password = string.Empty;

        //Constructors

        public Admin(Guid id, string firstName, string lastName, string email, int age, int salary, string password)
            : base(id, firstName, lastName, email, age) 
        {
            Salary = salary;
            Password = password;
        }

        public Admin(string firstName, string lastName, string email, int age, int salary, string password)
            : base(firstName, lastName, email, age)
        {
            Salary = salary;
            Password = password;
        }
        
        //Incapsulare

        public int Salary
        {
            get { return salary; }
            set
            {
                if(value < 3500)
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
                if(value.Length < 8)
                {
                    throw new ArgumentException("Parola trebuie sa aiba cel putin 8 caractere");
                }

                password = value;
            }
        }
    }
}