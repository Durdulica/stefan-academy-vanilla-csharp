namespace stefan_academy_vanilla_charp.Common
{
    public interface INotificator
    {
        string Name { get; }
        void Send(string message);
    }
}
