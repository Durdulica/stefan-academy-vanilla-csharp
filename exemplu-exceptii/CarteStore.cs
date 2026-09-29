using ExempluExceptii.Exceptii;

namespace ExempluExceptii
{
    public class CarteStore
    {
        private readonly List<Carte> carti = new();

        public void Adauga(Carte carte)
        {
            if (GasesteDupaTitlu(carte.Titlu) != null)
            {
                throw new DuplicateException("Cartea", carte.Titlu);
            }
            carti.Add(carte);
        }

        public Carte DupaTitlu(string titlu)
        {
            Carte? gasita = GasesteDupaTitlu(titlu);
            if (gasita == null)
            {
                throw new NotFoundException("Cartea", titlu);
            }
            return gasita;
        }

        public int Numar
        {
            get { return carti.Count; }
        }

        private Carte? GasesteDupaTitlu(string titlu)
        {
            foreach (Carte c in carti)
            {
                if (c.Titlu == titlu)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
