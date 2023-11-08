using Library_Administration.Servicios;
using Library_Administration;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSqlServer<LibraryContext>(builder.Configuration.GetConnectionString("cnLibrary"));

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBooksService, BookService>();

var app = builder.Build();

app.MapGet("/dbconnection", async ([FromServices] LibraryContext dbcontext) =>
{
    dbcontext.Database.EnsureCreated();
    return Results.Ok();
});

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
