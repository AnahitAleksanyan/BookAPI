using WebApplication4.Repositories.Implemetations;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Implementations;
using WebApplication4.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication4.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<SQLDBContext>(
    options =>
        options.UseSqlServer(connection)
    );


// Add services to the container.


builder.Services.AddScoped<IBookRepository, BookSQLRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<IPersonRepository, PersonSQLRepository>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService,CourseService>();

builder.Services.AddScoped<IEnrollmentsRepository, EnrollmentsRepository>();

builder.Services.AddScoped<IUserRepository, UserSQLRepository>();
builder.Services.AddScoped<IUserService, UserService>();











builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<LanguageGetterMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
