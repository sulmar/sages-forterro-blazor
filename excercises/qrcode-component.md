# 🎯 Zadanie: Strona dodawania produktu z podglądem i kodem QR

## 🧩 Cel:

Stwórz stronę Blazor, która umożliwia dodanie nowego produktu za pomocą formularza z walidacją. Po wypełnieniu formularza powinien pojawić się **podgląd produktu**, zawierający jego dane oraz **kod QR** wygenerowany na podstawie kodu kreskowego.

---

## 🛠️ Wymagania funkcjonalne:

1. Utwórz stronę `Products/Add.razor`, która zawiera:
 - formularz z polami:
   - Nazwa produktu – wymagane
   - Kod kreskowy 'Barcode' – wymagane, min. 6 znaków

- przycisk „Dodaj produkt”

2. Po wypełnieniu powinien przejść na stronę z podglądem produktu `Products/View.razor` i wyświetlić:
- nazwa produktu
- kod kreskowy
- kod QR, wygenerowany na podstawie pola `Barcode`, używając darmowego API:

4.  **kod QR**, wygenerowany na podstawie pola „Kod kreskowy”, używając darmowego API:
👉 `https://api.qrserver.com/v1/create-qr-code/?data=...&size=...`

## 🧩 Wskazówka:

Zaprojektuj i użyj komponent odpowiedzialny za renderowanie QR Code: `QrCode.razor` 

Komponent powinien przyjmować parametry:
- `Value` – zawartość kodu (np. kod kreskowy produktu),
- `Size` – rozmiar QR (opcjonalny, domyślnie `200`).


## 🧠 Rozszerzenia (dla chętnych):
Dodaj kolejne pola produktu: Cena, Opis, itp.