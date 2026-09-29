namespace stefan_academy_vanilla_charp.Common
{
    public interface INotificator
    {
        string Name { get; }
        string Send(string message);
    }
}
