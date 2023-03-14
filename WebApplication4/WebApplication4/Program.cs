using WebApplication4.Repositories.Implemetations;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Implementations;
using WebApplication4.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IBookRepository, BookRepository>();

builder.Services.AddSingleton<IBookService, BookService>();

builder.Services.AddSingleton<IPersonRepository, PersonListRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
