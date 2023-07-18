using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Servis kayýtlarý
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders(); // default olarak böyle bir kayýt var demek
builder.Logging.AddConsole();
builder.Logging.AddDebug();
//Log dosyasýnýn oluþturulacaðý dizini ve loglamanýn yapýlmasýný istediðim minimum seviyeyi belirttim.
builder.Logging.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Information);
builder.Logging.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Warning);
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
