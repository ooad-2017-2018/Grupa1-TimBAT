# Grupa1-TimBAT   

## Tema: Mreža za profesionalno povezivanje

## Članovi tima:
1. Arnautović Adnan
2. Bezdrob Hana
3. Teskeredžić Edvin

## Opis teme
Svrha sistema koji se razvija jeste da omogući kako individualcima, tako i firmama profesionalno povezivanje sa ljudima iz struke u svrhu kolaboracije na projektima. Ovaj sistem će olakšati pronalazak kompetentnog tima ljudi za implementaciju projekata koji su razvijeni konceptualno na način da je moguće pretraživanje korisnika na osnovu potrebnog skillseta za realizaciju određenog projekta. Ovaj sistem je posebno koristan za firme koje razvoj svojih projekata baziraju na unajmljivanju freelancera.

## Procesi
* Korisnik kreira račun unoseći tip profila (firma ili individualac), ime i prezime (u slučaju da se registruje firma, ovo polje je zamijenjeno njenim nazivom), datum rođenja (za firmu datum osnivanja), korisničko ime, e-mail adresu i šifru, pri čemu je polje za unos korisničkog imena neobavezno (ukoliko korisnik sam ne unese korisničko ime, bit će generisano na osnovu e-mail adrese). Za oba tipa profila obavezno je izabrati sliku profila, što je omogućeno na dva načina - odabirom postojeće datoteke ili upotrebom kamere kao eksternog uređaja.
* Korisnik ima mogućnost uređivanja svog profila na sljedeći način:
  * Može promijeniti korisničko ime, šifru, e-mail adresu i sliku
  * Može napisati kratki opis 
  * Može uploadati svoj CV u pdf formatu
  * Može dodati tehnologije i vještine iz liste ponuđenih opcija
  * Može dodati link na svoj github profil ili direktno postavljati kod projekta u tekstualnom obliku
* Svakom korisniku je omogućena pretraga ostalih korisnika te dodavanje istih u kontakte sa kojima u budućnosti želi ostvariti neki vid kolaboracije ili poslovnog odnosa
* Korisnicima je omogućeno kreiranje projekta (naziv, opis...) i odabir članova tima za njegov razvoj iz liste kontakata. Ako kontakti prihvate kolaboraciju, kreator projekta je obaviješten putem notifikacije
* Korisnik koji je kreirao projekat ima mogućnost da ga označi kao završenog i nakon toga svi učesnici projekta imaju pravo ocijeniti saradnju kao dobru ili lošu (putem points sistema), s tim da osoba koja je kreirala projekat može davati duple bodove

## Funkcionalnosti
* Kreiranje profila
* Prijava
* Uređivanje profila
* Pretraga korisnika po različitim kriterijima
* Dodavanje korisnika u kontakte
* Kreiranje, uređivanje i brisanje projekta
* Označavanje projekta kao završenog
* Ocjenjivanje saradnje na projektu
* Upravljanje korisnicima i aplikacijom od strane admina

## Akteri
* Administrator - nadgleda sve aktivnosti u sistemu
* Korisnik (obični ili firma) - kreira profil, uređuje ga, dodaje kontakte i projekte
