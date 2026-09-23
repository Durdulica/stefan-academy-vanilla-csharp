using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Factories
{
    public class StudentFactory : IUserFactory
    {
        public string Type => "STUDENT";

        public User Create(string[] fields)
        {
            return new Student(Guid.Parse(fields[1]), fields[2], fields[3], fields[4], Int32.Parse(fields[5]));
        }
    }
}
