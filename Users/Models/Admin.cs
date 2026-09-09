using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Admin : User, ITextMapper<Admin>
    {
        private int salary = 0;
        private string password = string.Empty;

        //Constructors

        public Admin(Guid id, string firstName, string lastName, string email, int salary, int age, string password)
            : base(id, firstName, lastName, email, age) 
        {
            Salary = salary;
            Password = password;
        }

        public Admin(string firstName, string lastName, string email, int salary, int age, string password)
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

        public string ToText(Admin item)
        {
            return "ADMIN," + Id + "," + FirstName + "," + LastName + "," + Email
                    + "," + Age + "," + Salary + "," + Password;
        }

       public Admin FromText(string text)
        {
            string []cuv = text.Split(',');

            return new Admin(Guid.Parse(cuv[0]), cuv[1], cuv[2], cuv[3], Int32.Parse(cuv[4]), Int32.Parse(cuv[5]), cuv[6]);
        }
    }
}