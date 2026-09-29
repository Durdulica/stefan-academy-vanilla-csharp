using ExempluExceptii.Exceptii;

namespace ExempluExceptii
{
    public class Carte
    {
        private string titlu = string.Empty;
        private int an;

        public Guid Id { get; }

        public Carte(Guid id, string titlu, int an)
        {
            Id = id;
            Titlu = titlu;
            An = an;
        }

        public string Titlu
        {
            get { return titlu; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ValidationException("Titlu", "nu poate fi gol");
                }
                if (value.Length < 2 || value.Length > 30)
                {
                    throw new ValidationException("Titlu", "trebuie sa aiba intre 2 si 30 de caractere");
                }
                titlu = value;
            }
        }

        public int An
        {
            get { return an; }
            set
            {
                if (value < 1450 || value > 2026)
                {
                    throw new ValidationException("An", "trebuie sa fie intre 1450 si 2026");
                }
                an = value;
            }
        }
    }
}
