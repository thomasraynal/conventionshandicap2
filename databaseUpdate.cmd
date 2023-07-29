set ASPNETCORE_ENVIRONMENT=%1

dotnet ef database update --context ConventionHandicapDbContext --project ConventionsHandicap.EntityFramework\ConventionsHandicap.EntityFramework.csproj 