using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Mappers;
using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Models.Students.Dtos;

namespace stefan_academy_vanilla_charp.Users.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository() 
            : base(new UserTextMapper(), Path.Combine("..","..","..","Data","users.txt")) { }

        public User FindById(Guid id)
        {
            foreach (var user in Items)
            {
                if (id.CompareTo(user.Id) == 0)
                {
                    return user;
                }
            }

            return null;
        }

        public User GetByFirstAndLastName(string firstName, string lastName)
        {
            foreach (var user in Items)
            {
                if (user.FirstName.CompareTo(firstName) == 0 && user.LastName.CompareTo(lastName) == 0)
                {
                    return user;
                }
            }

            return null;
        }
    }
}