using System.Reflection;
using Asp.Versioning;
using KeyVaultService;
using KeyVaultService.Framework.Managers;
using Microsoft.OpenApi.Models;

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
    
    opt.SwaggerDoc(Constants.API_VERSION,
        new OpenApiInfo
        {
            Title = Constants.API_TITLE,
            Version = Constants.API_VERSION,
            Description = Constants.API_DESCRIPTION
        });
    
    opt.IncludeXmlComments(
        Path.Combine(AppContext.BaseDirectory,
            $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

builder.Services.RegisterServicesFromFullScope();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint(Constants.SWAGGER_URL, Constants.API_VERSION);
    });
}

app.UseHttpsRedirection();

app.Run();