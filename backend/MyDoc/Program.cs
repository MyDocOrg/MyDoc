using Microsoft.EntityFrameworkCore;
using MyDoc.Application.BL;
using MyDoc.Application.DAL;
using MyDoc.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<PacienteDAL>();

builder.Services.AddScoped<PacienteBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint
    app.UseSwaggerUI(options =>
    {
        // Specify the Swagger endpoint and name it
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    }); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
