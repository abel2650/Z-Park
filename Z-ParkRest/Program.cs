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

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Tillader alle domæner (frontend på localhost osv.)
            .AllowAnyMethod() // Tillader GET, POST, PUT, DELETE osv.
            .AllowAnyHeader(); // Tillader alle headers (Authorization, Content-Type osv.)
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cors allow all
app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();