using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MovieApi.Core.Services;
using MovieApi.Infra.Configuration;
using MovieApi.RestAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>{
    opt.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString(DateTime.Today.ToString("yyyy-MM-dd"))
    });
    opt.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "My API - V1",
            Version = "v1"
        }
    );
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var connection = builder.Configuration["ConnectionStrings:desafio-ubots"];
builder.Services.AddInfra(connection);
builder.Services.AddScoped<FilmeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(configure =>
    {
        configure
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
