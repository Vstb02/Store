using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Store.Application.Extensions;
using Store.Domain.Identity;
using Store.Infrastructure.Middlewares;
using Store.Persistence.Extensions;
using Store.WebAPI;
using Store.WebAPI.Consumers;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration
        .WriteTo.Console();
});

builder.Services.ConfigureDbContext(Configuration);
builder.Services.ConfigureDependencyContainer();
builder.Services.ConfigureCommonContainer();

builder.Services.AddMemoryCache();

builder.Services.AddElasticsearch(Configuration);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JWT:SecurityKey").Value);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = Configuration["Jwt:Issuer"],
        ValidAudience = Configuration["Jwt:Audience"],
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "StoreAPI.xml");
    c.IncludeXmlComments(xmlPath);

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Store API", Version = "v1" });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
            });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    var cache = scopedProvider.GetRequiredService<IMemoryCache>();
    try
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.ReceiveEndpoint("user-status-event", e =>
            {
                e.Handler<User>(context =>
                {
                    cache.Remove(context.Message.Id);
                    cache.Set(context.Message, context.Message.Id);

                    return null;
                });
            });
        });

        await busControl.StartAsync(new CancellationToken());
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandlerMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CheckUserMiddleware>();

app.MapControllers();

app.Run();
