using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using MyDoc.Application.BO.Contants;
using MyDoc.Application.BO.Mappers;
using MyDoc.Application.DAL;
using MyDoc.Application.Helper;
using MyDoc.Application.Services;
using MyDoc.Infrastructure.AuthModels;
using MyDoc.Infrastructure.Models;
using MyDoc.Middleware;
using System.Text;
using System.Text.Json;

// Cargar variables de entorno desde el archivo .env en la raíz del workspace
var envPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".env");
if (File.Exists(envPath))
{
    Env.Load(envPath);
}

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.Local.json (for local secrets)
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);
builder.Configuration.AddEnvironmentVariables();

// Configurar JWT desde variables de entorno
builder.Configuration["Jwt:Key"] = Environment.GetEnvironmentVariable("JWT_KEY") 
    ?? builder.Configuration["Jwt:Key"];
builder.Configuration["Jwt:Issuer"] = Environment.GetEnvironmentVariable("JWT_ISSUER") 
    ?? builder.Configuration["Jwt:Issuer"];
builder.Configuration["Jwt:Audience"] = Environment.GetEnvironmentVariable("JWT_AUDIENCE") 
    ?? builder.Configuration["Jwt:Audience"];
builder.Configuration["Jwt:ExpiresMinutes"] = Environment.GetEnvironmentVariable("JWT_EXPIRESMINUTES") 
    ?? builder.Configuration["Jwt:ExpiresMinutes"] 
    ?? "60";

// Add services to the container.

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MyDoc api",
        Version = "v1"
    });

    // 🔐 Definición del esquema JWT
    c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingresa el token JWT así: Bearer {tu_token}"
    });

    // 🔒 Requerir el token para los endpoints
    c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("MYDOC_CONN") 
        ?? builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
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
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

                if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
                {
                    context.Token = authHeader.Substring("Bearer ".Length).Trim();
                    return Task.CompletedTask;
                }

                // 2️⃣ Si no hay header, intenta cookie
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

// Register mapper
builder.Services.AddScoped<ClinicMapper>();
builder.Services.AddScoped<DoctorMapper>();
builder.Services.AddScoped<PatientMapper>();
builder.Services.AddScoped<MedicineMapper>();
builder.Services.AddScoped<AppointmentStatusMapper>();
builder.Services.AddScoped<ClinicDoctorMapper>();
builder.Services.AddScoped<ConsultationMapper>();
builder.Services.AddScoped<PrescriptionMapper>();
builder.Services.AddScoped<PrescriptionMedicineMapper>();
builder.Services.AddScoped<MedicationScheduleMapper>();
builder.Services.AddScoped<NotificationMapper>();
builder.Services.AddScoped<MedicalHistoryMapper>();

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
// Swagger habilitado para producción (proyecto educativo)
app.MapOpenApi();
app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwaggerUI(options =>
{
    // Specify the Swagger endpoint and name it
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "mydoc-api");
});

// if (!builder.Configuration.GetValue<bool>("DisableHttpsRedirect"))
// {
//     app.UseHttpsRedirection();
// }

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health").AllowAnonymous();

app.MapGet("/", () => Results.Ok("MyDoc API is running"));
app.Run();
