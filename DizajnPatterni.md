# Projektni zadatak 8 - Dizajn patterni

## Interpreter pattern

### Problem:

U dobro strukturiranom okruženju često dolazi do različitih problema, koji bi bili lako rješivi kada bi se samo okruženje (domen) moglo opisati nekim 'jezikom'. Tada bi interpreter tog jezika mogao lako da riješi probleme koji se javljaju.

### Rješenje:

Interpreter pattern služi za evaluiranje gramatike nekog jezika i jezičkih izraza. Implementira se AbstractExpression 
interface koji koristi kompozitni pattern da bi riješio neki jezički problem. Obično se koriste TerminalExpression i 
CompoundExpression klase koje služe za rekurzivno rješavanje problema interpretacije nekog jezičkog izraza gdje je 
CompoundExpression neki dio pravila koji poziva drugo pravilo za obradu izraza, dok je TerminalExpression bazni 
slučaj za neko pravilo.

### U našem projektu:

Može se koristiti za provjeru validnosti šifre pri registraciji korisnika (npr. da li je uneseno dovoljno znakova, da li su velika i mala slova, da li ima brojeva i drugih znakova).

## Observer pattern

### Problem:

Kako se nameću novi zahtjevi, monolitni dizajn nije u stanju da skalira dobro.

### Rješenje:

Observer pattern se koristi ukoliko postoje jedna-na-više veze između objekata takve da ako se jedan objekat 
modifikuje, ostali će biti obavješteni automatski. Observer koristi tri actor klase: subjekat, observer i objekat. 
Observer nadzire subjekat i svaki put kad se on promijeni obavještavaju se objekti. Dobar primjer ovoga je aukcija: 
svako ima malu palicu koju diže da bi dao svoju ponudu, kad neko digne palicu, cijena na aukciji se diže i o tome se 
obavještavaju ostali učesnici aukcije.

### U našem projektu:

Može se koristiti za notifikacije korisniku u momentu kad mu dođe poruka od drugog korisnika.

## Strategy pattern

### Problem:

Želimo da se pridržavamo otvoreno-zatvorenog principa, te da u baznoj klasi enkapsuliramo detalje o samom interface-u, a implementacijske detalje sakrijemo u podklasama. Na taj način klijent ima isti interface, bez obzira na razne promjene 'ispod haube'.

### Rješenje:

Strategy pattern izdvaja algoritam iz matične klase i uključuje ga u posebne klase. Pogodan je kada postoje različiti 
primjenjivi algoritmi (strategije) za neki problem. Uklanja probleme sa razbacanim if iskazima u programu.
Struktura: Context klasa, IStrategy interfejs za sve algoritme, klase koje implementiraju algoritme. 

## Mediator pattern

### Problem:

Želimo dizajnirati komponente za višekratnu upotrebu, ali određene ovisnosti između tih komponenti stvaraju 'spaghetti code'.

### Rješenje:

Mediator pattern se koristi da reducira kompleksnost komunikacije između više objekata ili klasa. Ovaj pattern sadrži 
mediatorsku klasu koja se brine o komunikaciji između dvije klase ili više objekata te dvije klase. Tako se spriječava pojava 'spaghetti code-a'

### U našem projektu:

Može se koristiti za razmjenu poruka između nekoliko objekata klase Korisnik.

## Visitor pattern

### Problem:

Želimo nad istim objetkom izvršavati mnogo različitih i ne nužno povezanih operacija, bez da sama klasa postane 'prenapuhana'.

### Rješenje:

Visitor pattern dopušta razdvajanje algoritama od skeleta objekta na kojem djeluje. Dopušta dodavanje funkcija bez 
mijenjanja samih implementacija klasa. Cilj je da se iz samih klasa uklone operacije, već da se one izvršavaju preko visitor klasa (koje su zapravo podklase). U slučaju potrebe za novom operacijom, jednostavno se doda nova visitor podklasa.

## State pattern

### Problem:
Kada objektno ponašanje zavisi od stanja i okolnosti, ili kada je ponašanje aplikacije zavisno od mnogobrojnih 
case statementa koji kontrolišu izvršavanje zasnovano od stanja tokom rada aplikacije.

### Rješenje:
1.	Napraviti klasu koja će služiti kao okvirna klasa za klasu stanja mašine, i sa kojom će se klijent korisnik sporazumijevati
2.	Napraviti baznu klasu stanja koja će imati sve metode za interface mašine
3.	Izvesti novu klasu stanja za svako stanje, koja će overridat svaku metodu iz bazne klase koja je potrebna za to stanje
4.	okvirna klasa će predstavljati trenutno stanje
5.	Svaki klijent request na okvirnoj klasi će se prebacivati na trenutni objekat stanja, čiji će pointer biti u okvirnoj klasi
6.	Metode stanja mijenjaju okvirnu klasu na odgovarajuće stanje

## Iterator pattern

### Problem:
Postojanje mnogobrojnih struktura podataka sa malo sličnosti, te je potrebno abstraktirati put kroz te podatke da 
bi se formirali algoritmi za površno prolaženje kroz tih strutktura bez otkrivanje interne strukture.

### Rješenje:
1.	Uzeti željenu klasu kolekcije
2.	Dodati metodu "create_iterator()" koja pravi iterator klasu te dati privilegije tom iteratoru
3.	Dizajnirati taj iterator da može prolaziti kroz kolekciju bez problema
4.	Upisati metode kao što su first(), last(), next() itd. u tu iterator klasu, da bi klijent mogao raditi sa tim iteratorom

## Adapter pattern

### Problem:

Već kreiran sistem ili klasa ima funkcionalnosti koje su poželjne za naš sistem, ali nije kompatibilna sa načinom na kojim smo razvili sam sistem, te se sama po sebi ne može uklopiti i integrirati u sistem. 

### Rješenje:

Ima zadatak da proširi upotrebu klasa koje su već napisane, tj. koristi se kad nam je potreban 
drugačiji interfejs ali istovremeno ne želimo da promijenimo postojeću klasu.
Funkcioniše tako što kreira novu adapter klasu koja je posrednik između originalne klase i novog 
interfejsa. Poželjno ga je izbjeći ako klasa nema puno funkcionalnosti.
Sastavljen od klasa Client (surađuje sa drugim klasama preko ITarget interfejsa), ITarget interfejs 
(definiše zahtijevani interfejs), Adapter (implementira zahtijevani interfejs), Adaptee (definira 
interfejs za koji je prilagođavanje potrebno).
Može biti Class Adapter pattern i Object Adapter pattern, pri čemu je prvi korisniji ukoliko želimo 
override-ati ponašanje originalne klase a drugi ukoliko želimo definisati dodatno ponašanje.

## Bridge pattern

### Problem:

Klasa koju imamo često varira u svojoj implementaciji.

### Rješenje:

Ima zadatak da odvoji interfejs objekta od njegove implementacije s ciljem da aplikacija može imati 
više različitih apstrakcija i različitih implementacija za njih.
Pogodan za implementiranje nove verzije softvera pri čemu stara verzija mora moći nastaviti da radi.
Sastavljen od klasa Abstraction (interfejs apstrakcije) i Bridge (interfejs koji definiše 
apstrakciju i može imati više implementacija).

## Composite pattern

### Problem:

Aplikacija treba biti u stanju da vrši operacije nad hijerarhijom raznih objekta koji mogu biti kako jednostavni 
tako i komplikovani u strukturi. Nepoželjno je svaki put provjeravati tačan tip objekta, te onda odlučivati o operaciji.

### Rješenje:

Omogućava formiranje stabla pri čemu se i kompozicije i individualni objekti jednako tretiraju 
(omogućava iste funkcionalnosti i za jedne i za druge).
Sastavljen od klasa Client (manipulira objektima u kompoziciji), Icomponent interfejs (generički - 
definira operacije za objekte i implementira defaultno ponašanje), Component (implementira 
interfejs za osnovne objekte) i Composite (implementira interfejs za kompozitne objekte koristeći 
njihove pojedinačne komponente).

## Decorator pattern

### Problem:

Želimo da dodamo ponašanje za određene instance objekta unutar run-time, a nasljeđivanje nam je nepoželjno jer se primijeni na cijelu klasu
(sve instance).

### Rješenje:

Osnovna namjena Decorator paterna je da omogući dinamičko dodavanje novih elemenata i ponašanja 
(funkcionalnosti) postojećim objektima. Može se naprimjer koristi za implementaciju različitih 
kompresija videa kao i simultano prevođenje, itd.
Decorator pattern čine sljedeće klase: 
1. Component – Originalna klasa (koja sadrži interfejs koji se može mijenjati ili mu se mogu 
dinamički dodati operacije)
2. IComponent – interfejs koji identificira klase objekata koji trebaju biti dekorisani
3. Decorator – klasa koja odgovara IComponent interfejsu i implementira dinamički prošireni interfejs

## Facade pattern

### Problem:

Klijentu je potrebno pružiti pojednostavljen interface za sistem koji je sam od sebe veoma kompleksan.

### Rješenje:

Facade patern se koristi kada sistem ima više identificiranih podsistema (subsystems) pri čemu su 
apstrakcije i implementacije podsistema usko povezane.
Osnovna namjena Facade paterna je da osigura više pogleda visokog nivoa na podsisteme  
(implementacija podsistema skrivena od korisnika).
Može se više fasada postaviti oko postojećeg skupa podsistema i na taj način formirati više 
prilagođenih pogleda na sistem. 
Struktura Facade patterna sačinjena je od sljedećih klasa: 
1. Facade – definira i implementira jedinstven interfejs za skup operacija nekog podsistema
2. SubsystemClassN – definira i implementira N-ti interfejs u skupu interfejsa nekog podsistema
Implementacija podsistema je u okviru odvojenih imenovanih prostora (ili biblioteka), u
kojima se sa specifikatorima pristupa može postaviti željena vidljivost klase.

## Proxy pattern

### Problem:

Želimo da pružimo podršku za objekte koji su intenzivni što se utroška resursa tiče, ali ne želimo da ih instanciramo sve dok klijent 
to eksplicitno ne zatraži.

### Rješenje:

Namjena Proxy paterna je da omogući pristup i kontrolu pristupa stvarnim objektima. 
Proxy je obično mali javni surogat objekat koji predstavlja kompleksni objekat čija aktivizacija se 
postiže na osnovu postavljenih pravila. Proxy pattern rješava probleme kada se objekt ne može 
instancirati direktno (npr. zbog restrikcije pristupa). 
Struktura Proxy patterna je sastavljena od klasa:
1. Subject (ISubject) zajednički interfejs za realne/stvarne subjekte i proksije - surogate 
(proxies) koji omogućava da se oni koriste naizmjenično.
2. RealSubject je glavni objekat kojeg “predstavlja” proxy. 
3. Proxy - implementira isti interfejs kao RealSubject tako da se Proxy može koristiti umjesto 
RealSubject objekta. 
Proxy vrši kontrolu pristupa RealSubject objektu - može kreirati i brisati taj objekat.

## Abstract factory pattern

### Problem:

Da bi bilo moguće koristiti aplikaciju na više različitih sistema i uređaja (portability), ona mora enkapsulirati zahtjeve/uslove koje postavljaju ratličite platforme. Radi preglednosti, ta enkapsulacija se ne radi unaprijed, već se koristi abstract factory pattern sa ciljem da kreira familiju objekta koji su međusobno povezani.

### Rješenje:

Ovaj pattern odvaja definiciju klase od klijenta, što omogućava jednostavnu izmjenu i ažuriranje objekata, bez da se mijenja sam klijent.  
Na primjer, ako u fabrici automobila imamo istu mašinu koja pravi dijelove za različite modele auta, tada ta mašina predstavlja jedan vid abstract factory-a.

## Builder pattern

### Problem:

Aplikacija mora biti u stanju da kreira kompleksne objekte, sastavljene od drugih objekta (agregata). Specifikacija agregata se nalazi na sekundardnoj memoriji, dok se u primarnoj memoriji kreira kompleksni objekt na jedan od više mogućih načina.

### Rješenje:

Builder pattern odvaja algoritam za interpretiranje specifičnog produkta (npr. .rtf fajl), od algoritma koji kreira jedan od više različitih objekta (npr. ASCII). 'Director' poziva 'builder-a', koji kreira dio kompleksnog objekta. Kada se objekt kreira, klijent ga dobija nazad kao rezultat. Na primjer, neka je potrebno sastaviti Happy Meal u McDonald's-u. Svaki Happy Meal se sastoji od glavnog jela, priloga, i pića, pri čemu se ova 3 dijela mogu javiti u više različitih varijanti. Builder pattern omogućava jednak proces kreiranja kompleksnog objekta (Happy Meal) od manje kompleksnih objekata (dijelovi jela).

## Factory method pattern

### Problem:

Neka framework treba da standardizuje arhitekturalni model za široku lepezu aplikacija, ali istovremeno da dozvoljava individualnim aplikacijama da definišu svoje objekte i brinu se o njihovom instanciranju.

### Rješenje:
 
Factory method pattern omogućava da se kreira objekt tako da podklase mogu da odluče koju klasu treba instancirati. To znači da svaka podklasa može da implementira interface, i da implementacija tog interface-a može biti različita unutar samih klasa. Factory method pattern instancira posebnu klasu na osnovu metode koja se poziva u skladu sa informacijama koje daje klijent.

## Prototype pattern

### Problem:

Kreiranje novih objekata predstavlja operaciju koja je velik prostorni i/ili vremenski trošak. 

### Rješenje:

Prototype pattern omogućuje kloniranje već postojećih objekata pomoću interface-a IPrototype. Ako želimo da klasa implementira kloniranje svojih objekta, ona implementira ovaj interface.  

## Singleton pattern

### Problem:

Aplikaciji je potrebna jedna i samo jedna instanca određene klase. Pored toga, toj klasi se treba moći pristupiti sa globalnog nivoa.

### Rješenje:

Singleton pattern opisuje način na koji kreiramo interface za klase kod kojih želimo limitirati instance na jedan. Takav interface treba da sadrži privatni konstruktor, statički atribut na privatnom nivou, te metodu koja služi za pristupanje samom objektu.

### U našem projektu:

Naš projekat sadrži klasu BatNet koja predstavlja sistem i potrebna je samo jedna instanca te klase.

