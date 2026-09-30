using stefan_academy_vanilla_charp.Users.Mappers;

namespace stefan_academy_vanilla_charp.Common
{
    public class TextMapperCuJurnal<T> :  ITextMapper<T> 
    {
        private readonly ITextMapper<T> interior;
        public TextMapperCuJurnal(ITextMapper<T> interior) 
        {
            ArgumentNullException.ThrowIfNull(interior);
            this.interior = interior;
        }

        public string ToText(T item) 
        {
            Write(typeof(T).Name + " s-a transformat in text");
            return interior.ToText(item);
        }

        public T FromText(string text) 
        {
            Write("textul s-a transformat in " + typeof(T).Name);
            return interior.FromText(text);
        }

        public void Write(string message)
        {
            using var writer = new StreamWriter(Path.Combine("..", "..", "..", "Data", "jurnal.txt"), true);

            writer.WriteLine(typeof(T).Name + " cu jurnal: " + message);
            writer.Close();
        }
    }
}
