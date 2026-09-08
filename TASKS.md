# Academy — plan de lucru

Proiectul ăsta devine terenul pe care aplici pattern-urile din modulul `design-patterns-csharp`.

**Regula:** un task per rundă. Build + rulare înainte de fiecare commit. Nu treci la următorul până nu e verde cel curent.

**Ce NU se face:** nu rescrii tot proiectul. Fiecare task spune explicit ce atingi și ce lași în pace.

---

# T0 — Reparații, fără niciun pattern

Astea trebuie făcute primele: dacă refactorizezi peste ele, muți bug-ul într-o structură nouă și îl găsești mai greu.

## T0.0 — Proiectul nu compilează

Commit-ul `999504c` nu trece de build:

```
Users/Dtos/AdminUpdateRequest.cs(1,49): error CS0234:
The type or namespace name 'Admins' does not exist in the namespace
'stefan_academy_vanilla_charp.Users.Models'
```

Ai mutat `Admin`, `Student` și `Teacher` din `Users/Models/<X>s/Models/` direct în `Users/Models/` — mutare bună, curăță „Models" dublat din namespace. Dar ai actualizat `using`-urile doar în fișierele pe care le aveai deschise. `AdminUpdateRequest.cs` a rămas cu cel vechi.

**Aceeași greșeală ca la `design-patterns`, runda 4:** o redenumire sau o mutare nu e o editare într-un fișier, e o operație peste tot codul care se referă la el. În Visual Studio, mută clasa cu drag & drop în Solution Explorer — actualizează namespace-ul și `using`-urile singur.

**Regula, de acum înainte:** `Ctrl+Shift+B` înainte de fiecare commit. Nu „am terminat de scris", ci „am dat build și trece".

**Gata când:** `Build succeeded`, 0 erori.

## T0.1 — „Vezi cursurile" crapă

`ViewStudent.cs:126` → `CourseService.cs:29-39`

Rulează aplicația, loghează-te ca student, meniul `2` → `1`. Primești:

```
Unhandled exception. System.NullReferenceException
   at ViewStudent.AfisareCursuri() in ViewStudent.cs:line 131
```

Citește cu atenție ce trimiți și ce se caută:

```csharp
courseService.GetCourseListByEnrolmentId(enrolmentService.GetEnrolmentIdByStudentId(loggedUser.Id))
```

`GetEnrolmentIdByStudentId` întoarce ID-uri de **înrolare**. `GetCourseListByEnrolmentId` le dă mai departe lui `FindById`, care caută printre ID-uri de **curs**. Nu se potrivesc niciodată, deci `FindById` întoarce `null` de fiecare dată, iar lista se umple cu `null`-uri.

Îți lipsește un pas. O înrolare leagă un student de un curs — deci de la înrolare la curs se ajunge prin `CourseId`, nu prin `Id`.

**Gata când:** un student înscris la cursuri le vede afișate, iar unul neînscris primește „Nu sunteti inscris la niciun curs".

## T0.2 — „Modifică o carte" face cartea să dispară

`ViewStudent.cs:193`

Rulează: meniul `1` → `1` (vezi că ai cărți) → `3` (modifici una) → `1` din nou. Cartea a dispărut.

```csharp
BookUpdateRequest request = new BookUpdateRequest(book.Id, nume, DateTime.Now);
```

Uită-te la semnătura constructorului. Primul parametru **nu** e ce crezi tu că e. Apoi urmărește ce face `BookService.UpdateBook` cu el.

Ambele sunt `Guid`, deci compilatorul n-are ce să-ți spună. Asta e o clasă de greșeală care se va repeta — o rezolvăm din rădăcină la T5.

**Gata când:** după modificare cartea rămâne a ta, cu numele nou, și data la care ai adăugat-o inițial nu se schimbă.

## T0.3 — Data înscrierii se pierde

`Enrolment.cs:25-28`

```csharp
public Enrolment(Guid studentId, Guid courseId, DateTime createdAt) {
    StudentId = studentId;
    CourseId = courseId;
}
```

Citește constructorul până la capăt și numără parametrii folosiți.

**Gata când:** o înrolare creată cu o dată anume o păstrează.

## T0.4 — `CreateUser` construiește mereu un `User` gol

`Users/Services/UserService.cs:81-88`

În `999504c` ai scos lanțul de `if` pe tip din `CreateUser` și l-ai înlocuit cu:

```csharp
User newUser = new();
newUser.Create(request);
```

**Instinctul e corect** — lanțul ăla de `as` + `if` chiar trebuia să dispară, și l-ai înlocuit cu polimorfism, care e unealta pe care o ai. Dar uită-te ce tip are `newUser` pe prima linie.

`Create` e `virtual`, deci apelul se duce la implementarea **tipului real al obiectului**. Iar obiectul e un `User` — l-ai creat cu `new User()`. Deci se cheamă `User.Create`, niciodată `Teacher.Create` sau `Admin.Create`. Overrides-urile pe care le-ai scris în `Teacher.cs:98` și `Admin.cs` nu se execută niciodată.

Consecințe, în ordinea în care le vei vedea:
1. Creezi un profesor → salariul, orele și parola se pierd în tăcere.
2. `ToText` scrie linia ca `USER,...`.
3. La următoarea pornire, `switch`-ul din `ReadUsers` cade pe `default` → `ArgumentException("Eroare in fisierul de citire!!!")` și aplicația nu mai pornește.

Aici e lecția, și merită ținută minte: **polimorfismul alege ce metodă se execută pe un obiect care există deja. Nu poate alege ce clasă să construiască** — pe aia o decizi tu, înainte, când scrii `new`.

„Cine decide ce clasă construim" e o problemă separată, și are un pattern al ei: **Factory Method**, T3.

**Deocamdată:** pune la loc varianta care funcționa (lanțul de `if`), ca proiectul să fie corect. O scoatem definitiv la T3, cu unealta potrivită. Nu e un pas înapoi — e ordinea corectă: întâi funcționează, apoi e frumos.

**Gata când:** creezi un profesor, îl salvezi, repornești aplicația, și profesorul e tot profesor, cu salariu și parolă.

## T0.5 — DTO-urile moștenesc entitățile

`Books/Dtos/BookCreateRequest.cs:10` · `BookUpdateRequest.cs:10` · `Courses/Dtos/CourseCreateRequest.cs:10` · `CourseUpdateRequest.cs:10` · `Enrolments/Dtos/EnrolmentCreateRequest.cs:10` · `EnrolmentUpdateRequest.cs:10`

Șase clase de request încep la fel:

```csharp
public class BookUpdateRequest : Book
```

Un request care moștenește entitatea **este** entitatea: are `Id`-ul ei (un `Guid.NewGuid()` generat și aruncat la fiecare cerere), are toate câmpurile ei, trece prin validările ei și poate fi pasat oriunde se așteaptă un `Book`. Nu mai există nicio graniță între „ce cere clientul" și „ce ține baza de date".

Asta e cauza bug-ului pe care l-ai reparat la T0.2. Uită-te la linia veche:

```csharp
BookUpdateRequest request = new BookUpdateRequest(book.Id, nume, DateTime.Now);
```

`StudentId` exista în request **doar** pentru că e moștenit din `Book`. Nimeni n-a decis vreodată „la modificarea unei cărți, clientul are voie să schimbe proprietarul" — a venit gratis odată cu `: Book`. Tu ai reparat valoarea trimisă. Câmpul e tot acolo.

Pe `Users` ai făcut exact pe dos: `UserCreateRequest` (143 linii) și `UserUpdateRequest` (142 linii) sunt validarea din `User` copiată cu mâna. Aceeași întrebare, două răspunsuri opuse, în același proiect. Semnul că sunt două copii, nu una: în `Teacher`, setterul `Salary` doar scrie un mesaj și atribuie oricum, iar `WorkHours` aruncă excepție — și exact aceeași asimetrie e copiată în `TeacherCreateRequest`. Două locuri care trebuie ținute în pas la fiecare modificare.

### Ce construiești

**1. DTO-urile devin `record`-uri.** Un `record` e o clasă de date: câmpuri needitabile după construcție, egalitate pe valoare, un `ToString` folositor la depanare — și, cel mai important aici, compilatorul îți interzice moștenirea greșită:

```
error CS8864: Records may only inherit from object or another record
```

Adică decizia de design nu mai depinde de disciplina ta: `record ... : Book` **nu compilează**. Regula se aplică singură.

`Books/Dtos/BookCreateRequest.cs` — 18 linii devin una:

```csharp
namespace stefan_academy_vanilla_charp.Books.Dtos
{
    public record BookCreateRequest(Guid StudentId, string BookName, DateTime CreatedAt);
}
```

`Books/Dtos/BookUpdateRequest.cs` — și aici e partea importantă. Nu copia câmpurile vechi: întreabă-te **ce are voie să schimbe o modificare de carte**. Proprietarul, nu. Data adăugării, nu (ai stabilit-o la T0.2). Rămâne numele:

```csharp
namespace stefan_academy_vanilla_charp.Books.Dtos
{
    public record BookUpdateRequest(string BookName);
}
```

`BookCreateResponse` / `BookUpdateResponse`, la fel:

```csharp
public record BookCreateResponse(Guid Id, Guid StudentId, string BookName, DateTime CreatedAt);
public record BookUpdateResponse(Guid Id, string BookName, DateTime CreatedAt);
```

**2. Mapperele fac toată traducerea DTO ↔ entitate.** Ai deja o secțiune `//Mappers` în fiecare serviciu — problema e că nu trece totul prin ea. `CreateBook` cheamă mapperul, dar `UpdateBook` atribuie câmpurile cu mâna, direct în serviciu. `BookService.cs`, secțiunea de mappere, completă:

```csharp
public Book BookCreateRequestToBook(BookCreateRequest request)
{
    return new Book(request.StudentId, request.BookName, request.CreatedAt);
}

public void ApplyUpdate(Book book, BookUpdateRequest request)
{
    book.BookName = request.BookName;
}

public BookCreateResponse BookToBookCreateResponse(Book book)
{
    return new BookCreateResponse(book.Id, book.StudentId, book.BookName, book.CreatedAt);
}

public BookUpdateResponse BookToBookUpdateResponse(Book book)
{
    return new BookUpdateResponse(book.Id, book.BookName, book.CreatedAt);
}
```

`ApplyUpdate` e mapperul care lipsea. Are un singur rol: **este singurul loc din proiect care știe ce câmpuri ale unei cărți poate atinge o cerere de modificare.** Cât timp regula e scrisă într-o singură metodă, nu poate fi încălcată din greșeală în altă parte.

**3. `UpdateBook` nu mai atinge niciun câmp.** Serviciul găsește, verifică, deleagă:

```csharp
public BookUpdateResponse UpdateBook(Guid id, BookUpdateRequest request)
{
    Book book = FindById(id);
    if (book == null)
    {
        throw new ArgumentException("Cartea nu exista in baza de date");
    }

    ApplyUpdate(book, request);

    return BookToBookUpdateResponse(book);
}
```

**Regula, de acum înainte:** în afara secțiunii `//Mappers`, un serviciu nu scrie niciodată într-un câmp de entitate. Dacă te prinzi scriind `x.Ceva = request.Ceva` altundeva, îți lipsește un mapper.

**4. Apelul din `ViewStudent.cs:194` devine:**

```csharp
BookUpdateRequest request = new BookUpdateRequest(nume);
```

Uită-te bine la linia asta. **Nu mai există niciun `Guid` de pus pe poziția greșită.** Bug-ul de la T0.2 nu mai e reparat — e imposibil de scris. Asta e diferența dintre a corecta o linie și a închide o clasă de greșeli.

### Ce NU face `record`-ul

Să nu rămâi cu impresia că rezolvă tot. `EnrolmentCreateRequest(Guid StudentId, Guid CourseId, DateTime CreatedAt)` are în continuare doi `Guid` unul lângă altul, iar dacă îi inversezi compilatorul tace la fel de mult ca înainte. Împotriva **aia** ai două unelte: argumente numite la apel —

```csharp
new EnrolmentCreateRequest(studentId: loggedUser.Id, courseId: course.Id, createdAt: DateTime.Now)
```

— și, mai târziu, **T5 (Builder)**. `record`-ul rezolvă altceva: imutabilitatea, boilerplate-ul și moștenirea greșită.

### Ordinea

Book întâi, complet, cu build între pași. Abia după ce merge, aceeași operație la `Course` și `Enrolment` — sunt identice ca formă.

`UserCreateRequest` și `UserUpdateRequest` le lași **la urmă**: acolo nu e doar o moștenire de șters, ci 285 de linii de validare de mutat înapoi în `User`, `Teacher` și `Admin`. Le facem separat, după T1.

**Gata când:**
1. `grep -rn "Request : \|Response : " Books Courses Enrolments` nu mai găsește nimic (pe `Users`, `record`-urile pot moșteni `record`-uri, e în regulă).
2. Apelul de modificare a unei cărți nu mai conține niciun `Guid`.
3. `UpdateBook`, `UpdateCourse` și `UpdateEnrolment` nu mai au nicio atribuire de câmp în corpul lor.
4. Build verde, și scenariul de la T0.2 rulat din nou: modifici o carte, rămâne a ta, cu data inițială.

---

# T1 — Strategy: persistența într-un singur loc

**Pattern:** Strategy (lecția 1).

## De ce

Trei probleme, aceeași cauză.

**1. Scrierea și citirea stau în fișiere diferite și au divergat.** `Teacher.ToText` (`Users/Models/Teacher.cs:82-96`) scrie 8 câmpuri și uită parola. `Teacher(string text)` (`Users/Models/Teacher.cs:28-33`) citește `cuv[8]`. Deocamdată nu se vede, pentru că `Save()` nu e chemat niciodată — dar în clipa în care repari asta (T2), primul `Save()` scrie o linie de profesor fără parolă, iar la următoarea pornire aplicația moare cu `IndexOutOfRangeException` și baza de date rămâne nefolosibilă.

**2. Modelele știu că sunt salvate într-un fișier.** `ToText(int cnt, int size)` — modelul primește poziția lui în listă ca să decidă dacă pune `\n` la final. Un `Teacher` n-are de ce să știe câți alți useri există.

**3. Aceeași buclă, scrisă de patru ori:** `UserService.cs:129`, `BookService.cs:158`, `CourseService.cs:149`, `EnrolmentService.cs:152`. Plus `Path.Combine("..", "..", "..", "Data", ...)` în opt locuri.

## Ce construiești

Contractul — o strategie de traducere între obiect și linie de text:

```csharp
public interface ITextMapper<T>
{
    string ToText(T item);
    T FromText(string text);
}
```

Cele două metode stau **una sub alta, în aceeași clasă**. Asta e miezul task-ului: greșeala din punctul 1 devine greu de făcut, pentru că vezi ambele capete deodată.

Apoi contextul care le folosește:

```csharp
public class Repository<T>
{
    public Repository(string filePath, ITextMapper<T> mapper) { }

    public List<T> Load() { }
    public void Save(List<T> items) { }
}
```

`Repository` nu știe ce e un `Book` sau un `Teacher`. Știe doar să citească linii, să ceară mapper-ului să le traducă, și invers.

Clase de scris: `BookMapper`, `CourseMapper`, `EnrolmentMapper`, `UserMapper`.

`UserMapper` e cel interesant — el decide, după prefixul `STUDENT`/`TEACHER`/`ADMIN`, ce tip construiește. Lasă-l deocamdată cu un `switch`; îl curățăm la T3.

## Ce atingi

- Adaugi `ITextMapper<T>`, `Repository<T>` și cele 4 mappere.
- Scoți `ToText(cnt, size)` din `User`, `Student`, `Teacher`, `Admin`.
- Scoți `ReadX()`, `XListToString()`, `Save()` din cele 4 servicii; ele primesc un `Repository` și îl folosesc.
- Ștergi constructorii `Model(string text)` — treaba aia e acum a mapper-ului.

## Ce NU atingi

`ViewStudent`, `ViewLogIn`, DTO-urile, validările din setteri.

## Gata când

- `Data/*.txt` rămân neschimbate ca format — scopul e ca nimic din afară să nu observe refactorul.
- Adaugi manual un `TEACHER` **în mijlocul** lui `users.txt`, pornești aplicația, salvezi, o pornești din nou: pornește. Ăsta e testul care pică acum.
- Calea fișierului apare o singură dată per serviciu, nu de opt ori.
- Niciun model nu mai conține cuvântul „txt", „\n" sau vreo virgulă de separator.

---

# T2 — Observer: salvarea se întâmplă singură

**Pattern:** Observer (lecția 2). **Depinde de:** T1.

## De ce

Rulează aplicația, adaugă o carte, ieși, pornește din nou. Cartea nu mai e.

Toate cele patru servicii au un `Save()` (`BookService.cs:175`, `CourseService.cs:166`, `UserService.cs:139`, `EnrolmentService.cs:169`). Caută în tot proiectul cine îl cheamă: nimeni. Aplicația spune „adaugata cu succes" și pierde tot la ieșire.

Soluția evidentă e să pui `Save()` la finalul fiecărei metode care schimbă ceva. Merge — și e exact capcana din lecția 1: te obligă să-ți amintești, de fiecare dată, în fiecare metodă nouă. Prima dată când uiți, pierzi date fără niciun mesaj de eroare.

Aici sursa trebuie doar să **anunțe** că s-a schimbat ceva. Cine reacționează și cum nu e treaba ei.

## Ce construiești

```csharp
public interface IObservatorDate
{
    void DateModificate(string sursa);
}
```

Serviciile devin Subject: la fiecare `Create`, `Update`, `Delete` anunță observatorii.

Doi observatori:

| Clasă | Reacția |
|---|---|
| `AutoSave` | cheamă `Save()` pe repository |
| `JurnalAudit` | scrie în consolă ce s-a schimbat și când |

## Ce atingi

Cele 4 servicii (devin Subject), plus clasele noi. `Program.cs` sau `ViewLogIn` leagă observatorii la servicii.

## Ce NU atingi

Mapper-ele și `Repository` din T1.

## Gata când

- Adaugi o carte, ieși, pornești din nou: cartea e acolo.
- Te înscrii la un curs, ieși, pornești din nou: înscrierea e acolo.
- Ștergi `AutoSave` de la înregistrare și totul funcționează la fel, doar că nu se mai salvează. Dacă trebuie să modifici vreun serviciu ca să faci asta, Observer-ul nu e corect.
- În servicii nu apare cuvântul `Save`.

**Atenție** — capcană din lecția 2: `InscriereCurs` (`ViewStudent.cs:237`) adaugă direct în lista expusă de serviciu, sărind peste `CreateEnrolment`. Nicio notificare nu se va declanșa de acolo. Repară și asta.

---

# Ce urmează

Se deschid pe măsură ce facem lecțiile. Fiecare are deja locul lui în cod.

| Task | Pattern | Unde aterizează |
|---|---|---|
| T3 | Factory Method | `UserService.CreateUser` și `UserMapper` — răspunsul corect la ce ai încercat în T0.4 |
| T4 | Singleton (și de ce de obicei NU) | `ViewLogIn` și `ViewStudent` construiesc fiecare propriile servicii — ai două copii ale bazei de date în memorie |
| T5 | Builder | Constructorii `Teacher` și `Admin`. Uită-te la ordinea parametrilor în cele două, unul lângă altul. Apoi adu-ți aminte de T0.2 |
| T6 | Adapter | `System.Text.Json` pus în spatele lui `ITextMapper` — schimbi formatul de stocare fără să atingi vreun serviciu |
| T7 | State | `Book` capătă stări de împrumut: `Disponibila → Imprumutata → Restituita/Pierduta`, cu tranziții interzise |
| T8 | Decorator | `LoggingRepository` peste `Repository` |

---

# Restanțe, oricând între task-uri

- Nu există `.gitignore`. `bin/`, `obj/` și `.vs/` vor ajunge în git — exact ce am curățat la `design-patterns-csharp`.
- Build-ul trece cu **71 de warnings**. Citește-le: cele `CS8604` din `ViewStudent` spun că `Console.ReadLine()` poate întoarce `null` și tu îl folosești direct.
- `Int32.Parse(Console.ReadLine())` în meniuri: orice tastă nenumerică închide aplicația cu `FormatException`.
- `Data/students.txt` nu mai e folosit de nimeni — `users.txt` l-a înlocuit.
- `Console.WriteLine(aux)` rămas din depanare, în `CursTopStudenti` (`ViewStudent.cs:274`).
- `ViewLogIn.Logger()` se numește „Logger" dar face login.
- `GetBook` și `FindByName` caută cu `Contains`, nu cu egalitate: „Cartea" găsește „Cartea1".
- Parolele stau în clar în `users.txt`, iar studenții se loghează doar cu numele, fără parolă.
