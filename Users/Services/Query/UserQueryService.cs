using stefan_academy_vanilla_charp.Users.Models;
using stefan_academy_vanilla_charp.Users.Repositories;

namespace stefan_academy_vanilla_charp.Users.Services.Query
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository repository;

        public UserQueryService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User GetUser(Guid id) => repository.FindById(id);

        public User GetUserByFirstAndLastName(string firstName, string lastName) => repository.GetByFirstAndLastName(firstName, lastName);
    }
}
