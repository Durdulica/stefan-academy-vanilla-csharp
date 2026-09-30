namespace stefan_academy_vanilla_charp.Common
{
    internal class NotificatorFisier : INotificator
    {
        private readonly string path;
        public NotificatorFisier(string path)
        {
            this.path = path;
        }

        public string Name
        {
            get { return nameof(NotificatorFisier); }
        }

        public void Send(string message)
        {
            using var writer = new StreamWriter(path, true);
            writer.WriteLine(Name + ": " + message);
        }
    }
}
