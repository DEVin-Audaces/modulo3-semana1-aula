using projeto_pizza_api;
using projeto_pizza_api.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddTransient<ITransientExemploService, TransientExemploService>()
    .AddScoped<IScopedExemploService, ScopedExemploService>()
    .AddSingleton<ISingletonExemploService, SingletonExemploService>()
    .AddScoped<ITesteService, TesteService>();

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
