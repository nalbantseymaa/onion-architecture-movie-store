using MovieApi.Application;
using MovieApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Ortam değişkenini ve connection string'i ayarla
var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

// Register the persistence layer (DbContext'i burada kaydediyoruz)
//Uygulama başlarken servislerin DI’a eklenmesi gerekir.
// Burada AddPersistence extension method'unu çağırıyoruz
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
