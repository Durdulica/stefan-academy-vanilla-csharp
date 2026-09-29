namespace ExempluExceptii
{
    public enum MotivEsec
    {
        Niciunul,
        UtilizatorInexistent,
        ParolaGresita
    }

    public class RezultatLogin
    {
        public bool Reusit { get; }
        public MotivEsec Motiv { get; }

        private RezultatLogin(bool reusit, MotivEsec motiv)
        {
            Reusit = reusit;
            Motiv = motiv;
        }

        public static RezultatLogin Reuseste()
        {
            return new RezultatLogin(true, MotivEsec.Niciunul);
        }

        public static RezultatLogin Esueaza(MotivEsec motiv)
        {
            return new RezultatLogin(false, motiv);
        }
    }

    public class Autentificare
    {
        private readonly Dictionary<string, string> parole = new()
        {
            { "grozavu", "gicuEgrozav" }
        };

        public RezultatLogin Incearca(string utilizator, string parola)
        {
            if (!parole.ContainsKey(utilizator))
            {
                return RezultatLogin.Esueaza(MotivEsec.UtilizatorInexistent);
            }

            if (parole[utilizator] != parola)
            {
                return RezultatLogin.Esueaza(MotivEsec.ParolaGresita);
            }

            return RezultatLogin.Reuseste();
        }
    }
}
