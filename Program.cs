using LifeArmony_api.Models;
using LifeArmony_api.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<S_PlanAlimentacion>();

ConfigMongoDB.ConnectionString = builder.Configuration.GetSection("ConnectionStringMongoDB").Value;
ConfigMongoDB.DatabaseName = builder.Configuration.GetSection("DatabaseName").Value;
ConfigMongoDB.IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("IsSSL").Value);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:8100") // Asegúrate de cambiar esto por el origen real que necesitas permitir
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
