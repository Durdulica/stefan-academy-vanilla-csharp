using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Repositories
{
    public interface IUserRepository
    {
        User FindById(Guid id);

        User GetByFirstAndLastName(string firstName, string lastName);

        User GetByEmail(string email);

        void Add(User user);

        void Update(User user);

        void Remove(User user);
    }
}
