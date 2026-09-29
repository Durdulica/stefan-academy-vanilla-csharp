namespace stefan_academy_vanilla_charp.Common
{
    public class TextMapperCuJurnal<T> : ITextMapper<T>
    {
        private readonly ITextMapper<T> interior;

        public TextMapperCuJurnal(ITextMapper<T> interior) 
        {
            if (interior == null)
            {
                throw new ArgumentNullException(nameof(interior));
            }
            this.interior = interior;
        }

        public string Name => interior.Name + " cu jurnal";

        public string ToText(T item) 
        {
            Send(nameof(T) + " s-a fost transformat in text");
            return interior.ToText(item);
        }

        public T FromText(string text) 
        {
            Send("textul s-a transfomat in " + nameof(T));
            return interior.FromText(text);
        }

        public string Send(string message)
        {
            using var writer = new StreamWriter(Path.Combine("..", "..","..", "Data", "jurnal.txt"));
            
            writer.Write(Name + ": " + interior.Send(message));
            return "";
        }
    }
}
