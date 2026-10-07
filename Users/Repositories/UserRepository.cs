using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Mappers;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Repositories
{
    public class UserRepository : Repository<User>
    {
        private static UserRepository instance;

        public static UserRepository Instance
        {
            get 
            {
                if(instance == null)
                {
                    instance = new UserRepository();
                }

                return instance;
            }
        }

        private UserRepository() 
            : base(new TextMapperCuJurnal<User>(new UserTextMapper()), Path.Combine("..","..","..","Data","users.txt")) { }

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

        public User GetByEmail(string email) 
        {
            foreach (var user in Items)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
