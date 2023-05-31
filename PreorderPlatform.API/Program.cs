using PreorderPlatform.Service;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Dependency Injection
builder.Services.RegisterBusiness(builder.Configuration);
//builder.Services.AddDbContext<PreOrderSystemContext>(options
//    => options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext")));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
