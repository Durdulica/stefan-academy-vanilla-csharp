namespace ExempluExceptii.Exceptii
{
    public class ValidationException : AcademyException
    {
        public string Camp { get; }
        public string Regula { get; }

        public ValidationException(string camp, string regula)
            : base("Validare esuata pentru " + camp + ": " + regula)
        {
            Camp = camp;
            Regula = regula;
        }

        public override string MesajPentruUtilizator
        {
            get { return "Campul " + Camp + " nu e bun: " + Regula; }
        }
    }
}
