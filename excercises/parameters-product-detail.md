# Ćwiczenie: Przekazywanie parametrów na przykładzie produktów

## Cel:
Twoim zadaniem jest dodanie do listy produktów możliwości filtrowania ich na podstawie parametrów przekazywanych w **Query String**. Dodatkowo powinna być możliwość wyświetlenia strony szczegółów produktu.


## Wymagania funkcjonalne:

1. Strona szczegółów produktu (`ProductDetail.razor`):
- Strona ta wyświetla szczegóły produktu na podstawie **parametru trasy** (`productId`).
- Strona ta dodatkowo obsługuje **query string**, który może zawierać opcjonalny parametr `discount`, np. `?discount=true`.

2. Strona produktów (`ProductList.razor`):
- Strona główna zawiera listę produktów, z której użytkownik może przejść do szczegółów produktu.
- Każdy przycisk „Szczegóły” przekierowuje użytkownika do strony szczegółów produktu, przekazując parametr trasy (`productId`) i query string (`discount`).

Przykładowe URL:

`/products?color=red` — pokazuje produkty w kolorze czerwonym

`/products?1?discount=true` — pokazuje obniżoną cenę.

`/products/2?discount=false` — cena bez rabatu.

`/products/3` — brak rabatu, cena domyślna.