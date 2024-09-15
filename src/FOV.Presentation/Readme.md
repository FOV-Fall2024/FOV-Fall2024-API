## Add Migration

`dotnet ef migrations add IdentityUser -s .\FOV.Presentation\  -p .\FOV.Infrastructure\`


## Run Project
### Docker
`docker-compose up -d`
### Database migrate 
`dotnet ef database update -s .\FOV.Presentation\  -p .\FOV.Infrastructure\`

## Connect in RedisInsight and PgAdmin4
## connect 
Host=127.0.0.1;Port=5433;Database=RestaurantManagementDatabase;Username=admin;Password=admin;
## docker connect
Host=fov_database;Port=5432;Database=RestaurantManagementDatabase;Username=admin;Password=admin;