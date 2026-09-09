using stefan_academy_vanilla_charp.Common;

namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Student : User, ITextMapper<Student>
    {
        public Student(Guid id, string firstName, string lastName, string email, int age) 
            : base(id, firstName, lastName, email, age) { }

        public Student(string firstName, string lastName, string email, int age) 
            : base(firstName, lastName, email, age) { }


        public string ToText(Student item)
        {
            return "STUDENT," + Id + "," + FirstName + "," + LastName + "," + Email + "," + Age;
        }

        public Student FromText(string text) 
        {
            string[] cuv = text.Split(',');

            return new Student(Guid.Parse(cuv[0]), cuv[1], cuv[2], cuv[3], Int32.Parse(cuv[4]));
        }
    }
}