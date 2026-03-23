Rental at Uni Proj 1.0

    - Projekt przedstawia prosty system wypożyczalni sprzętu (np. laptopów, kamer, projektorów). 
    - Umożliwia zarządzanie użytkownikami, sprzętem oraz procesem wypożyczania.

Użytkowanie:
    - Jak otworzy się program pokaże się menu działać:
        - Do debugowania poszczególnych komend jest opcja "m" by wprowadzić dane do testowania.
        - Do zobaczenia demo działania komend (punkt 11-17 projektu) jest opjca "d". 



Architektura projektu

Projekt został podzielony na kilka głównych Folderów i Klas:

Hardware

    - Zawiera klasy reprezentujące sprzęt (np. Laptop, Camera, Projector) oraz ich buildery.
    - Klasy te extend'ują klasę Hardware.
    - Zastosowanie wzorca Builder pozwala na wygodne i czytelne tworzenie obiektów sprzętu.
    - Klasa bazowa Hardware umożliwia ujednolicenie wspólnych właściwości i łatwe rozszerzanie systemu o nowe typy urządzeń.

Users

    - Oddzielenie użytkowników od logiki biznesowej upraszcza zarządzanie danymi.
    - Projekt wymagał rozróżnienia Użytkowników na inne typy, zdecydowałem sie zastosować klasę Enum, ponieważ pozwala na łatwe rozszerzenie typów użytkowników (np. admin, standardowy użytkownik). Nie zakładamy jak w przypadku klas z folderu hardware, że użytkownicy będą się czymś więcej różnić niż typem oraz ile mogą mieć wypożyczeń.

Logic

Zawiera główną logikę biznesową.

    - Rental: 
        - Klasa asocjacyjna do przechowywania informacji co kto wypozyczył.
    - Service:
        - Separacja logiki od warstwy UI. Service wypuszcza dane które klasa UI potem wykorzystuje do stworzenia interfejus.
        - Service odpowiada za operacje systemowe (np. wypożyczanie), co centralizuje logikę.

Exceptions

    - Zawiera własne wyjątki (np. brak dostępności sprzętu, przekroczenie limitu).
    - Własne wyjątki poprawiają czytelność błędów.
    - Ułatwiają debugowanie i obsługę specyficznych przypadków biznesowych.

UI

    - Zawiera prostą warstwę interfejsu użytkownika (UI.cs).
    - Obsługuje dane z metod klasy service.
    - Obsługuje wyjątki (tylko dlatego żeby była oprawa graficzna wyjątku, użytkownik musi wiedzieć co źle napisał).


Pliki główne
    - Program.cs – punkt wejścia aplikacji
    - ShowcaseProgram.cs – przykładowe użycie systemu

