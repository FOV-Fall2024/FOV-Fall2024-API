## Add Migration

`dotnet ef migrations add IdentityUser -s .\FOV.Presentation\  -p .\FOV.Infrastructure\`


## Run Project
### Docker
`docker-compose up -d`
### Database migrate 
`dotnet ef database update -s .\FOV.Presentation\  -p .\FOV.Infrastructure\`