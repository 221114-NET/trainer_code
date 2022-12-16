using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/reflect", (Stream raw) => 
{
    StreamReader reader = new StreamReader(raw, Encoding.UTF8);
        
    return reader.ReadToEndAsync();
})
.WithName("Reflect")
.WithOpenApi();

app.Run();