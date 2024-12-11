var builder = WebApplication.CreateBuilder(args);

// Add services to the container(dependency injection)

var app = builder.Build();

// Configure the HTTP request pipeline

app.Run();
