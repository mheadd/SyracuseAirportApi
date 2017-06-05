# Syracuse Airport API

An API for flight data from the Syracuse Hancock International Airport.

A C# clone of [this project](https://github.com/UpstateData/syracuse-airport-api).

## Example usage

Get all flights: `/api/flights`

Get flight by flight number: `/api/flights/findByNumber?number=3800`

## Example response

```json

{
  "flight": {
    "@date": "06/05/17",
    "@claim": " ",
    "@remarks": "ON TIME",
    "@gate": "",
    "@actualtime": "1750",
    "@scheduletime": "1750",
    "@city": "NEWARK",
    "@flightnumber": "3800",
    "@airlinecode": "UA",
    "@indicator": "D",
    "@type": "A"
  }
}

```