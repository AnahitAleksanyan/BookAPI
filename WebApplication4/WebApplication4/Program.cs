using WebApplication4.Repositories.Implemetations;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Implementations;
using WebApplication4.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;



var builder = WebApplication.CreateBuilder(args);


// получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<SQLDBContext>(options =>
options.UseSqlServer(connection));


// Add services to the container.


builder.Services.AddScoped<IBookRepository, BookSQLRepository>();

//ToDo add IPersonService
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IPersonRepository, PersonSQLRepository>();

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
