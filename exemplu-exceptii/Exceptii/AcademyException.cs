namespace ExempluExceptii.Exceptii
{
    public abstract class AcademyException : Exception
    {
        protected AcademyException(string mesaj) : base(mesaj) { }

        protected AcademyException(string mesaj, Exception cauza) : base(mesaj, cauza) { }

        public abstract string MesajPentruUtilizator { get; }
    }
}
