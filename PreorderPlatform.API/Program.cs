using Microsoft.EntityFrameworkCore;
using PreorderPlatform.Entity.Entities;
using AutoMapper;
using PreorderPlatform.Service.ViewModels.User;
using PreorderPlatform.Entity.Repositories.UserRepository;
using PreorderPlatform.Service.ViewModels.AutoMapperProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PreorderPlatform.Service.Services.AuthService;
using PreorderPlatform.Service.ViewModels.AutoMapperProfile;
using PreorderPlatform.Service.Services.UserServices;
using PreorderPlatform.Entity.Repositories.UserRepositories;
using PreorderPlatform.Entity;
using PreorderPlatform.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<PreOrderSystemContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("PreOrderSystem")));

builder.Services.AddAutoMapper(typeof(ApplicationAutoMapperProfile));

// Add the following lines within the ConfigureServices method
builder.Services.RegisterData(builder.Configuration);
builder.Services.RegisterRepository();

builder.Services.RegisterBusiness(builder.Configuration);

//builder.Services.AddScoped<IUserRepository, UserRepository>();


    //builder.Services.AddScoped<UserService>();
    //builder.Services.AddScoped<AuthService>();
    //builder.Services.AddScoped<JwtService>();


var jwtSettings = builder.Configuration.GetSection("Jwt");
var jwtSecret = jwtSettings.GetValue<string>("Secret");
var key = Encoding.ASCII.GetBytes(jwtSecret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        ValidateLifetime = true
    };
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication(); // Add this line

app.UseAuthorization();
app.MapControllers();
app.Run();
