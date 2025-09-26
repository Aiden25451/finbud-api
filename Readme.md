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

## Setup

1. Download .NET 8
2. Install auth0 client
3. Login to auth client "auth login" use AUTH0_DOMAIN
4. Get JWT "auth0 test token -a \<AUTH0_AUDIENCE\> -s openid"
5. Use "nuget restore" to install needed packages
6. Launch app with "dotnet run"

- http://localhost:5062
- http://localhost:5062/swagger/index.html (Use this page for dev)

7. In swagger, click authorize and type "Bearer \<Access Token From auth client\>
