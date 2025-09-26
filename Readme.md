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

1. git clone https://github.com/Aiden25451/finbud-api.git
2. Visit the "How we are going to build a new .net backend" doc to add secrets files
3. Download .NET 8
4. Install auth0 client
5. Login to auth client "auth0 login" use AUTH0_DOMAIN
6. Get JWT "auth0 test token -a \<AUTH0_AUDIENCE\> -s openid"
7. Use "nuget restore" to install needed packages
8. Launch app with "dotnet run"

- http://localhost:5062
- http://localhost:5062/swagger/index.html (Use this page for dev)

9. In swagger, click authorize and type "Bearer \<Access Token From auth client\>
