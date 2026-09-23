using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Factories
{
    public class AdminFactory : IUserFactory
    {
        public string Type => "ADMIN";

        public User Create(string[] cuv)
        {
            return new Admin(Guid.Parse(cuv[1]), cuv[2], cuv[3], cuv[4], Int32.Parse(cuv[5]), Int32.Parse(cuv[6]), cuv[7]);
        }
    }
}
