using Store.Application.Interfaces;
using Store.Application.Services;
using Store.Infrastructure.Middlewares;
using Store.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITokenClaimsService, TokenClaimsService>();
builder.Services.ConfigureDbContext(config);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandlerMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
