
using HotelApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 1. Register repository for Dependency Injection
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

// 2. Add controllers
builder.Services.AddControllers();

var app = builder.Build();

// 3. Map controllers
app.MapControllers();

// 4. Run the app
app.Run();



