using ExempluExceptii.Exceptii;

namespace ExempluExceptii
{
    public class CititorDeLinii
    {
        public List<Carte> Citeste(string[] linii)
        {
            List<Carte> rezultat = new();

            for (int i = 0; i < linii.Length; i++)
            {
                try
                {
                    rezultat.Add(DinLinie(linii[i]));
                }
                catch (Exception cauza) when (cauza is FormatException || cauza is IndexOutOfRangeException)
                {
                    throw new FisierCoruptException(i + 1, linii[i], cauza);
                }
            }

            return rezultat;
        }

        private Carte DinLinie(string linie)
        {
            string[] cuv = linie.Split(',');
            return new Carte(Guid.Parse(cuv[0]), cuv[1], int.Parse(cuv[2]));
        }
    }
}
