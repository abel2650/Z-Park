using Microsoft.EntityFrameworkCore;
using Z_ParkLib;
using Z_ParkLib.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
string? consString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFUserContext>(options =>
    options.UseSqlServer(consString));


// Register UserRepositoryDB
builder.Services.AddScoped<UserRepositoryDB>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();