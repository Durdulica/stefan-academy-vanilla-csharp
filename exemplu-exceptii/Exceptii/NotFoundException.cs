namespace ExempluExceptii.Exceptii
{
    public class NotFoundException : AcademyException
    {
        public string Entitate { get; }
        public string Cheie { get; }

        public NotFoundException(string entitate, string cheie)
            : base(entitate + " cu cheia " + cheie + " nu exista")
        {
            Entitate = entitate;
            Cheie = cheie;
        }

        public override string MesajPentruUtilizator
        {
            get { return "Nu am gasit " + Entitate.ToLower() + ": " + Cheie; }
        }
    }
}
