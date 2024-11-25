# Karverket
OM PROSJEKTET

Prosjektets overordnede mål er å utvikle et system hvor brukere kan rapportere endringer eller problemer de har oppdaget på kartet, få oversikt over statusen på ulike rapporter de har sendt inn, og motta svar og tilbakemeldinger på rapportene, enten det fører til endringer eller ikke. Målet er at denne «Crowd-Sourcing»-løsningen skal være brukervennlig og tilgjengelig for alle, uavhengig av alder eller digital kompetanse.

## Applikasjonens oppsett
Programmet bruker følgende applikasjoner for å kjøre;

*  Docker: Gjennom docker kjøres to containere, som startes opp samtidig. En for databasen og en for selve applikasjonen.
*  MariaDB: Database, for lagring av brukere og innmeldingsdata.
*  Denne applikasjonen er utviklet som en ASP.NET MVC applikasjon.
*  IDE; Visual Studio(Windows), Rider (MAC)
  
## Hvordan applikasjonen kjøres
For å kunne ta i bruk denne applikasjonen og kjøre den følg stegene nedenfor:

## Windows
  1. Installere Docker.
  2. Clone koden fra dette repositoriet til din egne selvalgte lokale plassering
  3. kjør docker-compose up --build
  4. Gå inn i en nettleser, og skriv inn "localhost:8080" i søkefeltet.
  5. Du er nå klar for å bruke applikasjonen :)


COMMAND: docker-compose up --build

LINK: localhost:8080


### ADMIN BRUKER
E-post: admin@kartverket.no
passord: 1234
### SAKSBEHANDLER BRUKERE
* E-post: oslo@kartverket.no passord: 1234
* E-post: viken@kartverket.no passord: 1234
* E-post: innlandet@kartverket.no passord: 1234
* E-post: vestfoldogtelemark@kartverket.no passord: 1234
* E-post: agder@kartverket.no passord: 1234
* E-post: rogaland@kartverket.no passord: 1234
* E-post: vestland@kartverket.no passord: 1234
* E-post: møreogromsdal@kartverket.no passord: 1234
* E-post: trøndelag@kartverket.no passord: 1234
* E-post: nordland@kartverket.no passord: 1234
* E-post: tromsogfinnmark@kartverket.no passord: 1234

## Komponenter av applikasjonen

**MVC**
* MVC (Models, views, controllers) er et rammeverk for programvareutvikling. I MVC skilles det mellom data, logikk og visning.
  * Model: Model håndterer applikasjonens data, logikk og regler.
  * View: Views ansvarlig for å levere brukergrensesnittet som lar brukerne samhandle med applikasjonen.
  * Controller: Behandler brukerens input og fungerer som et mellomledd mellom views og models. I controlleren håndteres også logikk for å dirigere forespørsler til de          riktige stedene i en applikasjon.

**Entity Framework**
* Entity framework er en Object-Relational Mapper som gir muligheten til jobbe med databaser ved å bruke .NET-objekter, uten behov for direkte SQL-spørringer.

**Migrations**
* Migrations er en handling som lagre endringer til databasen og holde den oppdatert
* Kommandenene brukt var Add-Migration og Update-Database 

**Database**
* Databasen blir kjørt i din egen docker container og starter med Docker Compose
* Databasen blir nevnt og referet til i filen DBcontext

## Applikasjonens funksjonalitet og bruksområder

Denne applikasjonen er et verktøy utviklet for Kartverket som skal hjelpe brukere i å melde inn feil i kartdata, samt for kartverket å få oversikt over eventuelle feil. Ved en eventuell feil i kart, vil en bruker markere området og lage en rapport som sendes til en saksbehandler ved kartverket. Saksbehandlerer vil sjekke opp rapporten og enten avise eller godkjenne denne, brukerer får da en tilbakemelding på sin rapport.

## Funksjonaliteter

**Registrering av bruker**

En bruker har muligheten til å registrer seg og benytte systemet.

**Innlogging**

For at en bruker skal kunne ta i bruk applikasjonen, må de etter registrering, logge inn med epost og passord.

**Tilgangsnivå**

Innen applikasjonen eksisterer det ulike tilgangsnivå for forskjellige brukere.
De tre tilgangsnivåene er BRUKER, SAKSBEHANDLER og ADMIN.

**Brukere**

Opprette rapporter og sende inn.

**Saksbehandler**

Opprette rapporter, sende inn, svare rapporter, delegere rapporter.

**Admin**

(Høyeste tilgangsnivå) 
Opprette rapporter, sende inn, svare rapporter, delegere rapporter, tildele brukere til ulikt tilgangsnivå



## Innmeldingsoversikt

 **Kartinnmelding**
* Brukere har muligheten til å se alle innmeldinger de har gjort, og kan se hver individuelle innmeldings beskrivelse.
* Saksbehandlere kan se alle innmeldinger gjort av alle brukere.
* En saksbehandler har muligheten til å sortere innmeldinger basert på fylke og type (hav eller land).

