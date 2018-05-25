# Projektni zadatak 8 - Dizajn patterni

## Interpreter pattern

Interpreter pattern služi za evaluiranje gramatike nekog jezika i jezičkih izraza. Implementira se AbstractExpression 
interface koji koristi kompozitni pattern da bi riješio neki jezički problem. Obično se koriste TerminalExpression i 
CompoundExpression klase koje služe za rekurzivno rješavanje problema interpretacije nekog jezičkog izraza gdje je 
CompoundExpression neki dio pravila koji poziva drugo pravilo za obradu izraza, dok je TerminalExpression bazni 
slučaj za neko pravilo.

## Observer pattern

Observer pattern se koristi ukoliko postoje jedna-na-više veze između objekata takve da ako se jedan objekat 
modifikuje, ostali će biti obavješteni automatski. Observer koristi tri actor klase: subjekat, observer i objekat. 
Observer nadzire subjekat i svaki put kad se on promijeni obavještavaju se objekti. Dobar primjer ovoga je aukcija: 
svako ima malu palicu koju diže da bi dao svoju ponudu, kad neko digne palicu, cijena na aukciji se diže i o tome se 
obavještavaju ostali učesnici aukcije.
U našem projektu se observer može koristiti za notifikacije kad korisniku dođe poruka.

## Strategy pattern

Strategy pattern izdvaja algoritam iz matične klase i uključuje ga u posebne klase. Pogodan je kada postoje različiti 
primjenjivi algoritmi (strategije) za neki problem. Uklanja probleme sa razbacanim if iskazima u programu.
Struktura: Context klasa, IStrategy interfejs za sve algoritme, klase koje implementiraju algoritme. 

## Mediator pattern

Mediator pattern se koristi da reducira kompleksnost komunikacije između više objekata ili klasa. Ovaj pattern sadrži 
mediatorsku klasu koja se brine o komunikaciji između dvije klase ili više objekata te dvije klase.

## Visitor pattern

Visitor pattern dopušta razdvajanje algoritama od skeleta objekta na kojem djeluje. Dopušta dodavanje funkcija bez 
mijenjanja samih implementacija klasa.

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

Ima zadatak da odvoji interfejs objekta od njegove implementacije s ciljem da aplikacija može imati 
više različitih apstrakcija i različitih implementacija za njih.
Pogodan za implementiranje nove verzije softvera pri čemu stara verzija mora moći nastaviti da radi.
Sastavljen od klasa Abstraction (interfejs apstrakcije) i Bridge (interfejs koji definiše 
apstrakciju i može imati više implementacija).

## Composite pattern

Omogućava formiranje stabla pri čemu se i kompozicije i individualni objekti jednako tretiraju 
(omogućava iste funkcionalnosti i za jedne i za druge).
Sastavljen od klasa Client (manipulira objektima u kompoziciji), Icomponent interfejs (generički - 
definira operacije za objekte i implementira defaultno ponašanje), Component (implementira 
interfejs za osnovne objekte) i Composite (implementira interfejs za kompozitne objekte koristeći 
njihove pojedinačne komponente).

## Decorator pattern

Osnovna namjena Decorator paterna je da omogući dinamičko dodavanje novih elemenata i ponašanja 
(funkcionalnosti) postojećim objektima. Može se naprimjer koristi za implementaciju različitih 
kompresija videa kao i simultano prevođenje, itd.
Decorator pattern čine sljedeće klase: 
1. Component – Originalna klasa (koja sadrži interfejs koji se može mijenjati ili mu se mogu 
dinamički dodati operacije)
2. IComponent – interfejs koji identificira klase objekata koji trebaju biti dekorisani
3. Decorator – klasa koja odgovara IComponent interfejsu i implementira dinamički prošireni interfejs

## Facade pattern

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
