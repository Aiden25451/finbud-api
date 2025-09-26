# FinBud RestAPI

## Description

FinBud RestAPI is a ASP.NET core web app which serves the website [FinBud](https://FinBud.ca). FinBud currently implements a SupaBase DB.

## Structure

- Controllers: Handle routing and high level logic, calls Services/ to work
- Data: Contains logic for calls to database
- Dto: Contains data structures for requests and results
- Extensions: Serves only to breakup program.cs to make it more readable
- Models: Contains full definition of data structures
- Services: Contains business logic, calls Data/ to work
