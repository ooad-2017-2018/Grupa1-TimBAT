# Grupa1-TimBAT   

![alt text](https://raw.githubusercontent.com/ooad-2017-2018/Grupa1-TimBAT/master/logo2.jpg)


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
* Kreiranje profila, nakon čega korisnik dobija e-mail sa verifikacijskim kodom
* Prijava - korisnik unosi e-mail adresu ili korisničko ime te šifru
* Uređivanje profila - korisniku je omogućeno da promijeni šifru (nakon čega prima e-mail upozorenja), korisničko ime, sliku (pri čemu može birati da li će to biti korištenjem kamere ili odabirom datoteke), te e-mail adresu. Pored toga, omogućeno je dodavanje podataka pored postojećih, kao što su CV, opis profila, kodovi te tehnologije koje korisnik poznaje (pri čemu može birati iz liste ponuđenih tehnologija, ili napraviti proizvoljan unos)
* Pretraga korisnika po različitim kriterijima - korisničko ime. e-mail adresa i tehnologije koje poznaje
* Dodavanje korisnika u kontakte, pri čemu korisnik koji je primio zahtjev dobija notifikaciju
* Kreiranje, uređivanje i brisanje projekta
* Označavanje projekta kao završenog, pri čemu svi korisnici koji su učestvovali u izradi projekta dobijaju notifikaciju da je projekat završen i da trebaju ocijeniti ostale saradnike
* Ocjenjivanje saradnje na projektu, pri čemu se svi saradnici međusobno ocjenjuju i osoba koja je kreirala projekat može davati duple bodove
* Upravljanje korisnicima i aplikacijom od strane administratora - administrator upravlja sadržajem aplikacije tako što osigurava da se ne pojavljuje neprimjeren sadržaj, da nije moguće zloupotrebljavanje sistema (npr. da dva korisnika konstantno kreiraju zajedničke projekte bez koda i daju ocjene jedan drugom), da korisnici ne kreiraju lažne profile te da pri korištenju aplikacije ne dolazi do tehničkih problema (nemogućnost dodavanja projekta, kolaboratora itd.)

## Akteri
* Administrator - nadgleda sve aktivnosti u sistemu
* Korisnik (obični ili firma) - kreira profil, uređuje ga, dodaje kontakte i projekte
