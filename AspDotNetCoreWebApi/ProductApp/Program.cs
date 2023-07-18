using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Servis kay�tlar�
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders(); // default olarak b�yle bir kay�t var demek
builder.Logging.AddConsole();
builder.Logging.AddDebug();
//Log dosyas�n�n olu�turulaca�� dizini ve loglaman�n yap�lmas�n� istedi�im minimum seviyeyi belirttim.
builder.Logging.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Information);
builder.Logging.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Warning);
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
