# Sprint 0 - Game Design Document : Tower Defense
Naam: Jaysen van der Wal

Klas: SD2A

Datum: 08/09/2025

## 1. Titel en elevator pitch
Titel: Tower Tactics

Elevator pitch, maximaal twee zinnen:
Leuke artstyle en goeie gameplay. Ook is het erg interactief.


## 2. Wat maakt jouw tower defense uniek
Het heeft een leuke artstyle en leuke gameplay.

## 3. Schets van je level en UI
Maak een schets op papier of digitaal en voeg deze afbeelding toe aan je repository. Voeg in deze sectie de afbeelding in.

Je schets bevat minimaal:
1. Het pad waar de vijanden over lopen met beginpunt en eindpunt.
2. De plaatsen waar torens gebouwd kunnen worden.
3. De locatie van de basis of goal die verdedigd moet worden.
4. De UI onderdelen geld, wave teller, levens, startknop en pauzeknop.
5. Een legenda met symbolen of kleuren voor torens, vijanden, pad, basis en UI.

## 4. Torens
Toren 1 naam, bereik, schade, unieke eigenschap.
Enrique, hele map. 50dmg, breekt de soundbarrier.

Atlas, **Bereik:** Groot, **Schade:** 100 dmg splash (gebiedsschade), **Unieke eigenschap:** Werpt rotsblokken die meerdere vijanden tegelijk raken.



Eventuele extra torens:

## 5. Vijanden
Vijand 1 naam, snelheid, levens, speciale eigenschap.
Gorlock, 1km/h, 5, eet dingen op.

Vijand 2 naam, snelheid, levens, speciale eigenschap.
Adrian, 10km/h, hij explained de friendgroup

Eventuele extra vijanden:

## 6. Gameplay loop
Beschrijf in drie tot vijf stappen wat de speler steeds doet.
1. enemies attacken

2. speler bouwt toren

3. Speler probeert te verdedigen

4. Enemies proberen naar het einde te komen

5. Speler verdient geld met enemies doden en kan meer towers maken.

## 7. Progressie
Leg uit hoe het spel moeilijker wordt naarmate de waves doorgaan. Denk aan sterkere vijanden, kortere tussenpozen, hogere kosten of lagere beloningen.

Sterkere vijanden en hogere prijzen voor betere torens.

## 8. Risico’s en oplossingen volgens PIO
- **Probleem 1:** Toren wordt kapot gemaakt
    
    - **Impact:** Minder verdediging
        
    - **Oplossing:** Je moet een nieuwe toren plaatsen
        
- **Probleem 2:** Vijanden worden te sterk of te snel
    
    - **Impact:** Ze lopen door je verdediging heen en je verliest levens
        
    - **Oplossing:** Je kan torens upgraden of speciale vaardigheden inzetten (bijv. slow, stun, ultieme aanval)
        
- **Probleem 3:** Je hebt te weinig geld om torens te bouwen
    
    - **Impact:** Je verdediging groeit niet mee met de golven, waardoor je kans op verlies groter wordt
        
    - **Oplossing:** Systeem voor extra inkomsten toevoegen (bv. interest, speciale ‘gold-miner’ toren of bonus voor combo-kills)
  
## 9. Planning per sprint en mechanics
Schrijf per sprint welke mechanics jij oplevert in de build. Denk aan voorbeelden zoals vijandbeweging over een pad, torens plaatsen, doel kiezen en schieten, waves starten, UI voor geld en levens, upgrades, jouw unieke feature.

Sprint 1 mechanics: Tower plaatsen

Sprint 2 mechanics: enemy's

Sprint 3 mechanics: Tower destroyen

Sprint 4 mechanics: Schieten met tower

Sprint 5 mechanics: Money + levels


## 10. Inspiratie
Noem een bestaande tower defense game die jou inspireert en wat je daarvan meeneemt of juist vermijdt.
Bloons TD

## 11. Technisch ontwerp mini

Lees dit korte voorbeeld en vul daarna jouw eigen keuzes in.

Voorbeeld ingevuld bij 11.1 Vijandbeweging over het pad
- Keuze:
Vijanden volgen punten A, B, C en daarna de goal.
- Risico:
Een vijand loopt een punt voorbij of blijft hangen.
- Oplossing:
Als de vijand dichtbij genoeg is kiest hij het volgende punt. Bij de goal gaat één leven omlaag en verdwijnt de vijand.
- Acceptatie:
Tien vijanden lopen van start naar de goal zonder vastlopers en verbruiken elk één leven.
Alle tien vijanden bereiken achtereenvolgens elk waypoint binnen één seconde na elkaar.

### 11.1 Vijandbeweging over het pad
- Keuze: 
- Risico:
- Oplossing:
- Acceptatie:


### 11.2 Doel kiezen en schieten
- Keuze:
- Risico:
- Oplossing:
- Acceptatie:

### 11.3 Waves en spawnen
- Keuze:
- Risico:
- Oplossing:
- Acceptatie:

  
### 11.4 Economie en levens
- Keuze:
- Risico:
- Oplossing:
- Acceptatie:

### 11.5 UI basis
- Keuze:
- Risico:
- Oplossing:
- Acceptatie:
