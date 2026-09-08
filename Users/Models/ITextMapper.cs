namespace stefan_academy_vanilla_charp.Users.Models
{
    public interface ITextMapper<T>
    {
        string ToText(T item);
        T FromText(string text);
    }
}
