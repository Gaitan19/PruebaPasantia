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
            IssuerSigningKey = GetSymmetricSecurityKey(builder.Configuration),
            ValidateIssuer = false,
            ValidateAudience = false
            
        };
    }
    );

var app = builder.Build();


//

static SymmetricSecurityKey GetSymmetricSecurityKey(IConfiguration configuration)
{
    var keyValue = configuration.GetSection("JWT:key").Value;
    

    if (keyValue is null)
    {
        keyValue = null!;
    }
   
    var keyBytes = Encoding.UTF8.GetBytes(keyValue);
    
    return new SymmetricSecurityKey(keyBytes);
}
//
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
