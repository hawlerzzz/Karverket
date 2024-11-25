# Karverket
OM PROSJEKTET 

A challenge Kartverket faces today, as an organization, is making sure the map data can be updated and correct at all times. When looking at the current system used by Kartverket, it is eye-opening how difficult it is to send a report on an issue seen on a map, whether that be a wrong street name, changed roads, or a new hiking trail. The system is difficult to navigate through, leading many to either quit while trying to report in an issue found or to not even report issues in the first place which has huge ramifications on the organization’s map data and the information they can provide for its nation. This leads to a need for a solution in which reporting an issue found can be done in a user-friendly manner which both improves the map data with updates from its user, but also the inkling to report an issue in the first place knowing that it can be done and handled efficiently.

The project’s overall goal is to develop a system where you can report in changes or issues found on the map, get to see the status on the different rapports they have sent in and receive answers and feedback on their reports whether that results into change or not. The goal is for this ‘Crowd-Sourcing’ solution to be user friendly and accessible for anyone to use, no matter their age or digital competency. 

## Applikasjonens oppsett
Programmet bruker følgende applikasjoner for å kjøre;

*  Docker: Gjennom docker kjøres to containere, som startes opp samtidig. En for databasen og en for selve applikasjonen.
*  MariaDB: Database, for lagring av brukere og innmeldingsdata.
*  Denne applikasjonen er utviklet som en ASP.NET MVC applikasjon.
*  IDE; Visual Studio(Windows), Rider (MAC)
  
## Hvordan applikasjonen kjøres
For å kunne ta i bruk denne applikasjonen og kjøre den følg stegene nedenfor:

## Windows og Mac
  1. Installere Docker.
  2. Clone koden fra dette repositoriet til din egne selvalgte lokale plassering
  3. skjør docker-compose up --build
  4. 


COMMAND: docker-compose up --build

LINK: localhost:8080


### ADMIN BRUKER
E-post: admin@kartverket.no
passord: 1234

## Komponenter av applikasjonen

## Applikasjonens funksjonalitet og bruksområder

Denne applikasjonen er et verktøy utviklet for Kartverket som skal hjelpe brukere i å melde inn feil i kartdata, samt for kartverket å få oversikt over eventuelle feil. Ved en eventuell feil i kart, vil en bruker markere området og lage en rapport som sendes til en saksbehandler ved kartverket. Saksbehandlerer vil sjekke opp rapporten og enten avise eller godkjenne denne, brukerer får da en tilbakemelding på sin rapport.

## Funksjonaliteter

**Registrering av bruker**

En bruker har muligheten til å registrer seg og benytte systemet.

**Innlogging**

For at en bruker skal kunne ta i bruk applikasjonen, må de etter registrering, logge inn med epost og passord.

**Tilgangsnivå**

Innen applikasjonen eksisterer det ulike tilgangsnivå for forskjellige brukere.
De tre tilgangsnivåene er brukere, saksbehandlere og admins.

**Brukere**

Opprette rapporter og sende inn.

**Saksbehandler**

Opprette rapporter, sende inn, svare rapporter, delegere rapporter.

**Admin**

(Høyeste tilgangsnivå) 
Opprette rapporter, sende inn, svare rapporter, delegere rapporter, tildele brukere til ulikt tilgangsnivå

## Kartinnmelding

## Innmeldingsoversikt
