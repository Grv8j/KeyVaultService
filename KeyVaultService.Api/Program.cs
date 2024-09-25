using System.Reflection;
using Asp.Versioning;
using KeyVaultService;
using KeyVaultService.Framework.Managers;
using KeyVaultService.Persistence;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = ApiVersion.Default;
    opt.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddSwaggerGen(opt =>
{
    opt.UseOneOfForPolymorphism();
    opt.UseAllOfToExtendReferenceSchemas();
    
    opt.SwaggerDoc(Constants.Api.API_VERSION,
        new OpenApiInfo
        {
            Title = Constants.Api.API_TITLE,
            Version = Constants.Api.API_VERSION,
            Description = Constants.Api.API_DESCRIPTION
        });
    
    opt.IncludeXmlComments(
        Path.Combine(AppContext.BaseDirectory,
            $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

builder.Services.RegisterServicesFromFullScope();
builder.Services.RegisterPersistenceLayer(
    builder.Configuration
        .GetConnectionString(Constants.Configuration.CONNECTION_STRING_KEY_NAME));

builder.Host.UseSerilog((host, conf) =>
    conf.ReadFrom.Configuration(host.Configuration));
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint(Constants.Api.SWAGGER_URL, Constants.Api.API_VERSION);
    });
}

app.UseHttpsRedirection();

app.Run();