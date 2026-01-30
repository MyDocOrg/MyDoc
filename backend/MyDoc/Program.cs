using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyDoc.Application.Services;
using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.AuthModels;
using MyDoc.Infrastructure.Models;
using MyDoc.Middleware;
using System.Text;
using System.Text.Json;
using MyDoc.Application.Helper;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.Local.json (for local secrets)
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// AUTHENTICATION & AUTHORIZATION
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwt = builder.Configuration.GetSection("Jwt");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt["Key"])
            ),
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                if (context.Request.Cookies.ContainsKey("access_token"))
                {
                    context.Token = context.Request.Cookies["access_token"];
                }

                return Task.CompletedTask;
            },

            OnChallenge = context =>
            {
                context.HandleResponse();

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                var response = ApiResponse<object>.Fail(
                    message: "Invalid or expired token",
                    status: StatusCodes.Status401Unauthorized
                );

                return context.Response.WriteAsync(
                    JsonSerializer.Serialize(response)
                );
            },

            OnForbidden = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";

                var response = ApiResponse<object>.Fail(
                    message: "You do not have permission to access this resource",
                    status: StatusCodes.Status403Forbidden
                );

                return context.Response.WriteAsync(
                    JsonSerializer.Serialize(response)
                );
            }
        };
    });

// Register DAL services
builder.Services.AddScoped<AppointmentDAL>();
builder.Services.AddScoped<AppointmentStatusDAL>();
builder.Services.AddScoped<ClinicDAL>();
builder.Services.AddScoped<ClinicDoctorDAL>();
builder.Services.AddScoped<ConsultationDAL>();
builder.Services.AddScoped<DoctorDAL>();
builder.Services.AddScoped<MedicalHistoryDAL>();
builder.Services.AddScoped<MedicationScheduleDAL>();
builder.Services.AddScoped<MedicineDAL>();
builder.Services.AddScoped<NotificationDAL>();
builder.Services.AddScoped<PatientDAL>();
builder.Services.AddScoped<PrescriptionDAL>();
builder.Services.AddScoped<PrescriptionMedicineDAL>();

// Register Application services
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<AppointmentStatusService>();
builder.Services.AddScoped<ClinicService>();
builder.Services.AddScoped<ClinicDoctorService>();
builder.Services.AddScoped<ConsultationService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<MedicalHistoryService>();
builder.Services.AddScoped<MedicationScheduleService>();
builder.Services.AddScoped<MedicineService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<PrescriptionService>();
builder.Services.AddScoped<PrescriptionMedicineService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ApplicationProvider>();
builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<CurrentUserHelper>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCors", policy =>
    {
        policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("DefaultCors");

// Configure custom middleware pipeline (order matters!)
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
