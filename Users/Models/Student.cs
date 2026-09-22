namespace stefan_academy_vanilla_charp.Users.Models
{
    public class Student : User
    {
        public Student(Guid id, string firstName, string lastName, string email, int age) 
            : base(id, firstName, lastName, email, age) { }

        public Student(string firstName, string lastName, string email, int age) 
            : base(firstName, lastName, email, age) { }

    }
}
