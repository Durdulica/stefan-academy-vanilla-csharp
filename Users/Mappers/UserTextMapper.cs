using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Mappers
{
    public class UserTextMapper : ITextMapper<User>
    {
        public string ToText(User item)
        {
            return "USER," + item.Id + "," + item.FirstName + "," + item.LastName + "," + item.Email + "," + item.Age;
        }

        public User FromText(string text) 
        {
            string[] cuv = text.Split(',');

            return new User(Guid.Parse(cuv[1]), cuv[2], cuv[3], cuv[4], Int32.Parse(cuv[5]));
        }
    }
}
