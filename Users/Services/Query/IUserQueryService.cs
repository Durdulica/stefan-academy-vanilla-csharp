using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Users.Services.Query
{
    public interface IUserQueryService
    {
        User GetUser(Guid id);

        User GetUserByFirstAndLastName(string firstName, string lastName);
    }
}
