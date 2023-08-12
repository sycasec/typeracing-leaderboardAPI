# CSG Type Racing Backend API
## if database is run locally, please do the following steps
### Setup postgres
- Download pgadmin
- if prompted, please always use "root" as password
- create new database "typeRacingDB"

### run server
- clone this repository, navigate to clone directory.
- within the directory enter the commands,
    - `dotnet restore`
    - `dotnet ef database update
    - `dotnet publish configuration --Release`
    - `dotnet run .\bin\Release\net7.0\typeRacingAPI.dll`
