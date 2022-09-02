using Microsoft.EntityFrameworkCore;
using projeto_pizza_api;
using projeto_pizza_api.DataBase;
using projeto_pizza_api.DI;
using projeto_pizza_api.Models;
using projeto_pizza_api.Repositories;
using projeto_pizza_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jamil = builder.Configuration.GetConnectionString("PizzaDB");

builder.Services.AddDbContextFactory<PizzaDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaDB"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddTransient<ITransientExemploService, TransientExemploService>()
    .AddScoped<IScopedExemploService, ScopedExemploService>()
    .AddSingleton<ISingletonExemploService, SingletonExemploService>()
    .AddScoped<ITesteService, TesteService>();


//DI Para Services
builder.Services.AddScoped<IPizzaService, PizzaService>();

//DI Para Repositories
builder.Services.AddScoped<IPizzaRepository<PizzaModel>, PizzaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
