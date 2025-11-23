using HORP_CORP_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using HORPIncorp.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

string authority = builder.Configuration["Auth0:Authority"] ?? throw new ArgumentNullException("Auth0:Authority");
string audience = builder.Configuration["Auth0:Audience"] ?? throw new ArgumentNullException("Auth0:Audience");

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddAuthentication(option =>
{
 option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
 option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
 options.Authority = authority;
 options.Audience = audience;
});

builder.Services.AddAuthorization(options =>
{
 options.AddPolicy("delete:catalog", policy => policy.RequireAuthenticatedUser().RequireClaim("scope", "delete:catalog"));
});

builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite("Data Source=../Registrar.sqlite", b => b.MigrationsAssembly("HORPIncorp.Api")));

builder.Services.AddCors(options =>
{
 options.AddDefaultPolicy(builder =>
 {
 builder.WithOrigins("http://localhost:3001")
 .AllowAnyHeader()
 .AllowAnyMethod();
 });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
 app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
