<details>
<summary>Hva?</summary>

## Hva er Kafka?
- Open source
- Event prosessering og streaming
- Optimalisert for effektivitet og stort volum
- Enkelt oppsummert: en veldig god meldingskø
</details>

<details>
<summary>Men det finnes jo allerede andre message queues?</summary>

## Ja, hvorfor skal jeg bruke kafka?
- Enkelt å skalere horisontalt
- Pålitelig og fleksibelt
- Laget for stort volum og lav latency
- Robust; data blir replikert
- Data forblir lagret (så lenge man vil - og kan rekjøres)

## Men...
- Mer komplisert å sette opp og komme i gang
- Kan være tungt og kostbart å kjøre

### Så når bør jeg bruke det?
Det er få ting som er bedre enn Kafka dersom du har stort volum som du trenger å håndtere raskt og robust.
Til små applikasjoner, og til lokalutvikling er det kanskje enklere å starte med RabbitMQ.

Men... kafka til lokalbruk er ganske enkelt også - når man kan det...

</details>

<details>
<summary>Hvordan?</summary>

## Hvordan kommer jeg i gang?
- Kan kjøres hvor som helst, også i skyen
- Består av produsenter (producers) og konsumenter (consumers)
- Kjøre i docker container via WSL
</details>