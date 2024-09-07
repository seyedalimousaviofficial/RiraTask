using Microsoft.EntityFrameworkCore;
using RiraTask.Data;
using RiraTask.Repos;
using RiraTask.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<AppDbContext>(option =>
{
	option.UseSqlServer(config.GetConnectionString("DefCon"));
});
builder.Services.AddScoped<IPersonRepo, PersonBusiness>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<PeopleService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
