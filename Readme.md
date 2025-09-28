# FinBud RestAPI

## Description

FinBud RestAPI is a ASP.NET core web app which serves the website [FinBud](https://FinBud.ca). FinBud currently implements a SupaBase DB.

## Structure

- .github/workflows: Currently just logic to redeploy aws lambda on commit to main
- Authorization: Handle auth0 authentication and authorization
- Controllers: Handle routing and high level logic, calls Services/ to work
- Data: Contains logic for calls to database
- Dto: Contains data structures for requests and results
- Extensions: Serves only to breakup program.cs to make it more readable
- Mapping: Functions to transform Dtos and Models
- Models: Contains full definition of data structures
- Services: Contains business logic, calls Data/ to work

## Setup

1. git clone https://github.com/Aiden25451/finbud-api.git
2. Visit the "How we are going to build a new .net backend" doc to add secrets files
3. Download .NET 8
4. Install "auth0 client"
5. Login to auth client "auth0 login" use AUTH0_DOMAIN
6. Get JWT "auth0 test token -a \<AUTH0_AUDIENCE\> -s openid", select user and Finbud Frontend Local
7. Use "nuget restore" to install needed packages
8. Launch app with "dotnet run"

- http://localhost:5062
- http://localhost:5062/swagger/index.html (Use this page for dev)

9. In swagger, click authorize and type "Bearer \<Access Token From auth0 client\>" (This will give user access to authorization routes)

## Link to API

https://xmcajo4o7osu3saaj3mbq5lwey0jubsv.lambda-url.us-east-2.on.aws/swagger/index.html
