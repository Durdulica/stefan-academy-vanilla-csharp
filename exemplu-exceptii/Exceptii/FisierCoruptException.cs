namespace ExempluExceptii.Exceptii
{
    public class FisierCoruptException : AcademyException
    {
        public int NumarLinie { get; }
        public string Continut { get; }

        public FisierCoruptException(int numarLinie, string continut, Exception cauza)
            : base("Linia " + numarLinie + " nu poate fi citita: " + continut, cauza)
        {
            NumarLinie = numarLinie;
            Continut = continut;
        }

        public override string MesajPentruUtilizator
        {
            get { return "Fisierul de date e stricat la linia " + NumarLinie + "."; }
        }
    }
}
