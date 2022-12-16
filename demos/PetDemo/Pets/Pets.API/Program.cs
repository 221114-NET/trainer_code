using Microsoft.AspNetCore.DataProtection.Repositories;
using Pets.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = File.ReadAllText("./../../../../../ConnectionString.txt");
builder.Services.AddSingleton<IRepository>(sp => new SQLRepository(connectionString, sp.GetRequiredService<ILogger<SQLRepository>>()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
