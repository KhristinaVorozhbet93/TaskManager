using Microsoft.EntityFrameworkCore;
using TaskManager.DataEntityFramework;
using TaskManager.DataEntityFramework.Repositories;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Services;
using TaskManager.WebAPI;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var msSqlConfig = builder.Configuration
   .GetRequiredSection("MsSqlConfig")
   .Get<MsSqlConfig>();
if (msSqlConfig is null)
{
    throw new InvalidOperationException("MsSqlConfig is not configured");
}

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer
($"Server = {msSqlConfig.ServerName}; Database = TaskManager; " +
$"User Id = {msSqlConfig.UserName}; Password = {msSqlConfig.Password}; TrustServerCertificate=True"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
builder.Services.AddScoped<INoteRepository, NoteRepositoryEF>();

builder.Services.AddScoped<NoteService>();

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
