 using TareasAPI.Data;
 using TareasAPI.Services;
 using Microsoft.AspNetCore.Authentication.JwtBearer;
 using Microsoft.IdentityModel.Tokens;
//


using TestTareasAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//

//

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dbContext
builder.Services.AddSqlServer<GtareasContext>(builder.Configuration.GetConnectionString("TareaConnection"));
//Service
builder.Services.AddScoped<TareaService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

 

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

builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("AdminTipo", "Super"));
});

var app = builder.Build();


//

//
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
