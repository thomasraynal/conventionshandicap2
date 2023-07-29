
set ASPNETCORE_ENVIRONMENT=%2

dotnet ef migrations add %1 --context ConventionHandicapDbContext --project ConventionsHandicap.EntityFramework\ConventionsHandicap.EntityFramework.csproj
