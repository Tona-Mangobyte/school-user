using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString(
    builder.Environment.IsDevelopment() ? "DefaultConnection_Local" : "DefaultConnection_Cloud"
);
var ValidIssuer = builder.Configuration["Jwt:Issuer"];
var ValidAudience = builder.Configuration["Jwt:Audience"];
var IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!));

builder.Services.AddControllerClass();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerAndSecurity();
builder.Services.AuthenticationAndAuthorization(ValidIssuer, ValidAudience, IssuerSigningKey);
builder.Services.AddPersistence(connectionString);
builder.Services.AddExternalLibraries(connectionString);
builder.Services.AddServicesLifetime();
builder.Services.ConfigureApiBehaviors();
builder.Services.AddResilenceStrategy();

var app = builder.Build();

app.ConfigurePersistenceScoped();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.ConfigureHangfireSettings();

app.Run();
