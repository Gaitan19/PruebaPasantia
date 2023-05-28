 using TareasAPI.Data;
 using TareasAPI.Services;

 using Newtonsoft.Json;
 
 
 var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dbContext
builder.Services.AddSqlServer<GtareasContext>(builder.Configuration.GetConnectionString("TareaConnection"));
//Service
builder.Services.AddScoped<TareaService>();

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
