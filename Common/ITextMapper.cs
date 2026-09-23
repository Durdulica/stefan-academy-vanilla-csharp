namespace stefan_academy_vanilla_charp.Common
{
    public interface ITextMapper<T> : INotificator
    {
        string ToText(T item);
        T FromText(string text);
    }
}
