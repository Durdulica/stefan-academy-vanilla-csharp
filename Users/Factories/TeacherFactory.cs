using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Factories
{
    public class TeacherFactory : IUserFactory
    {
        public string Type => "TEACHER";

        public User Create(string[] fields)
        {
            return new Teacher(Guid.Parse(fields[1]), fields[2], fields[3], fields[4], int.Parse(fields[5]),
                int.Parse(fields[6]), int.Parse(fields[7]), fields[8]);
        }
    }
}
