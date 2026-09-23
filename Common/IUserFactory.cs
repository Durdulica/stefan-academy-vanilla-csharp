using stefan_academy_vanilla_charp.Users.Models;

namespace stefan_academy_vanilla_charp.Common
{
    internal interface IUserFactory
    {
        string Type { get; }
        User Create(string[] fields);
    }
}
