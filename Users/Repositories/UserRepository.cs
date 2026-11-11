using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Users.Mappers;
using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
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
            : base(new UserTextMapper(), Path.Combine("..","..","..","Data","users.txt")) { }

        public User GetByFirstAndLastName(string firstName, string lastName)
            => Items.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

        public User GetByEmail(string email) => Items.FirstOrDefault(s => s.Email == email);
    }
}
