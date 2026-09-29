namespace ExempluExceptii.Exceptii
{
    public class DuplicateException : AcademyException
    {
        public string Entitate { get; }
        public string Cheie { get; }

        public DuplicateException(string entitate, string cheie)
            : base(entitate + " cu cheia " + cheie + " exista deja")
        {
            Entitate = entitate;
            Cheie = cheie;
        }

        public override string MesajPentruUtilizator
        {
            get { return Entitate + " \"" + Cheie + "\" e deja in lista."; }
        }
    }
}
