using TareasAPI.Data;
using TareasAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TestTareasAPI.Services;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la conexión a la base de datos
//builder.Services.AddSqlServer<GtareasContext>(builder.Configuration.GetConnectionString("TareaConnection"));
builder.Services.AddSqlServer<GtareasContext>(builder.Configuration.GetConnectionString("TareaConnection"));
//Service
builder.Services.AddScoped<TareaService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

 
// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Tareas", Version = "v1" });
});


// Configurar autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            
            ValidateIssuerSigningKey = true,
            //IssuerSigningKey = GetSymmetricSecurityKey(builder.Configuration),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });

// Configurar autorización
builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("AdminTipo", "Super"));
});



var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Tareas v1");
    });
}

    
//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
