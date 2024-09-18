using Core.Interfaces;
using Core.Repository;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
        .AddJsonOptions(JsonOptions =>
                JsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddEndpointsApiExplorer(); builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Olsoftware Api", Version = "v1" });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }

    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Logging.ClearProviders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<PruebaServiceDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdOlSoftware"),
    sqlServerOptionsAction: options =>
    {
        options.EnableRetryOnFailure();
    });
});

builder.Services.AddScoped<IStoreProcedureRepository, StoreProcedureRepository>(); 
builder.Services.AddScoped<IProductoService, ProductoService>();






var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
