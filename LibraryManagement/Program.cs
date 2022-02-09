using AutoMapper;
using LibraryManagement.Config;
using LibraryManagement.Middlewares;
using LibraryManagement.Models.Context;
using LibraryManagement.Repository;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
    .SetMinimumLevel(LogLevel.Debug)
    .AddConsole());
// Add services to the container.

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<MyPostgreSQLContext>(options =>
                options.UseNpgsql(connection));

//Configuring Dependency Injection
builder.Services.AddScoped<ILoggerRepository, LoggerRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Services.AddControllers();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

//Configuring AutoMapper
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
//app.UseRequestResponseLogging();
app.UseRequestResponseLogging();
//app.UseMiddleware<LoggingMiddleware>();
app.UseExceptionHandler("/error");

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

