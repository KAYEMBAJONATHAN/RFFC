
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RFFC.Data;
using RFFC.Interfaces;
using RFFC.Mapping;
using RFFC.Middleware;
using RFFC.Services;


var builder = WebApplication.CreateBuilder(args);

// Register DBContext
builder.Services.AddDbContext<DBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddScoped<IRFCService, RFCService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ISignupService, SignupService>();
builder.Services.AddScoped<IPasswordHasher<RFFC.Entities.User>, PasswordHasher<RFFC.Entities.User>>();
builder.Services.AddScoped<IJwtService, JwtService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapHealthChecks("/health");
app.MapControllers();

app.Run();