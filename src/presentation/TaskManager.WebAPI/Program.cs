using Microsoft.EntityFrameworkCore;
using TaskManager.WebAPI;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string path = "task.db";
//builder.Services.AddDbContext<AppDbContext>(options =>
//options.UseSqlServer($"DataSource = {path}"));
//if (path == null) throw new ArgumentException(nameof(path));

builder.Services.AddOptions<MsSqlConfig>()
    .BindConfiguration("MsSqlConfig")
   .ValidateDataAnnotations()
   .ValidateOnStart();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
