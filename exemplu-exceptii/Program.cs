using ExempluExceptii;
using ExempluExceptii.Exceptii;

internal class Program
{
    private static readonly CarteStore store = new();

    public static void Main()
    {
        Titlu("1. Validare: titlu gol");
        Incearca(() => store.Adauga(new Carte(Guid.NewGuid(), "", 2020)));

        Titlu("2. Validare: an imposibil");
        Incearca(() => store.Adauga(new Carte(Guid.NewGuid(), "Ion", 1200)));

        Titlu("3. Adaugare corecta");
        Incearca(() =>
        {
            store.Adauga(new Carte(Guid.NewGuid(), "Ion", 1920));
            Console.WriteLine("   OK, in lista sunt " + store.Numar + " carti");
        });

        Titlu("4. Duplicat");
        Incearca(() => store.Adauga(new Carte(Guid.NewGuid(), "Ion", 1920)));

        Titlu("5. Cautare care nu gaseste");
        Incearca(() => store.DupaTitlu("Morometii"));

        Titlu("6. Fisier stricat la linia 2");
        Incearca(() => new CititorDeLinii().Citeste(new string[]
        {
            Guid.NewGuid() + ",Ion,1920",
            Guid.NewGuid() + ",Baltagul,o-mie-noua-sute"
        }));

        Titlu("7. Login gresit - NU e o exceptie");
        Autentificare auth = new();
        RezultatLogin r = auth.Incearca("grozavu", "parolaGresita");
        Console.WriteLine("   reusit=" + r.Reusit + "  motiv=" + r.Motiv);
        Console.WriteLine("   utilizatorul vede: " + Explica(r));
    }

    private static void Incearca(Action actiune)
    {
        try
        {
            actiune();
        }
        catch (ValidationException ex)
        {
            Console.WriteLine("   [validare]  " + ex.MesajPentruUtilizator);
            Console.WriteLine("   camp=" + ex.Camp);
        }
        catch (DuplicateException ex)
        {
            Console.WriteLine("   [duplicat]  " + ex.MesajPentruUtilizator);
        }
        catch (NotFoundException ex)
        {
            Console.WriteLine("   [lipsa]     " + ex.MesajPentruUtilizator);
            Console.WriteLine("   entitate=" + ex.Entitate + " cheie=" + ex.Cheie);
        }
        catch (FisierCoruptException ex)
        {
            Console.WriteLine("   [date]      " + ex.MesajPentruUtilizator);
            Console.WriteLine("   cauza reala: " + ex.InnerException?.GetType().Name
                              + " - " + ex.InnerException?.Message);
        }
        catch (AcademyException ex)
        {
            Console.WriteLine("   [academy]   " + ex.MesajPentruUtilizator);
        }
    }

    private static string Explica(RezultatLogin r)
    {
        if (r.Reusit)
        {
            return "Bine ai venit!";
        }
        return "Nume sau parola gresite.";
    }

    private static void Titlu(string text)
    {
        Console.WriteLine();
        Console.WriteLine("=== " + text + " ===");
    }
}
