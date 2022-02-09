using AutoMapper;
using LibraryManagement.Config;
using LibraryManagement.Middlewares;
using LibraryManagement.Models.Context;
using LibraryManagement.Repository;
using LibraryManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Microsoft.OpenApi.Models;

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Library Management",
        Version = "v1",
        Description = "System to manage a library",
        Contact = new OpenApiContact
        {
            Name = "Lucas Fuziyama",
            Url = new Uri("https://www.linkedin.com/in/lucas-fuziyama/")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    
});


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
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Management V1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

