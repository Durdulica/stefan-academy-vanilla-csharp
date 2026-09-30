namespace stefan_academy_vanilla_charp.Common
{
    public class NotificatorTest : INotificator
    {
        public string Name { get { return nameof(NotificatorTest); } }

        public void Send(string message)
        {
            Console.WriteLine(Name + " " + message);
        }
    }
}
