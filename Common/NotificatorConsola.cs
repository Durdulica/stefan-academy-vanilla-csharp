namespace stefan_academy_vanilla_charp.Common
{
    internal class NotificatorConsola : INotificator
    {
        public string Name
        {
            get { return nameof(NotificatorConsola); }
        }

        public void Send(string message)
        {
            Console.WriteLine(Name + ": " + message);
        }
    }
}
