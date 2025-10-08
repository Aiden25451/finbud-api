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
4. Install "auth0 client"
5. Login to auth client "auth0 login" use AUTH0_DOMAIN
6. Get JWT "auth0 test token -a \<AUTH0_AUDIENCE\> -s openid", select user and Finbud Frontend Local
7. Use "nuget restore" to install needed packages
8. Launch app with "dotnet run"

- http://localhost:5062
- http://localhost:5062/swagger/index.html (Use this page for dev)

9. In swagger, click authorize and type "Bearer \<Access Token From auth0 client\>" (This will give user access to authorization routes)


## Endpoints

UserInfo Controller:
GET /api/UserInfo/ --> 200 OK, 404 NOT FOUND
POST /api/UserInfo --> 200 OK, 400 BAD REQUEST 
PUT /api/UserInfo --> 200 OK, 404 NOT FOUND
DELETE /api/UserInfo --> 204, 

UserHistory Controller:
GET /api/UserHistory/ --> 200 OK, 404 NOT FOUND
POST /api/UserHistory/ --> 201 CREATED, 400 BAD REQUEST
PUT /api/UserHistory/ --> 200 OK, 400 BAD REQUEST
DELETE /api/UserHistory/ --> 204 NO CONTENT

UserAcheivement Controller:
GET /api/UserAchievement --> return list of all achievements by user id -> 200 OK, 404 NOT FOUND
GET /api/UserAchievement/AchievementId --> return user achievement of specified achievement id for given user -> 201 CREATED, 404 NOT FOUND

POST /api/UserAchievement --> enter new user acheivement in data table for this user only -> 200 OK, 400 BAD REQUEST

PUT /api/UserAchievement/ --> update the status and or value, verify that the user can update it -> 200 OK, 404 NOT FOUND

  
Achievement Controller:
GET /api/Achievement/AID --> entry from table --> not implemented yet
