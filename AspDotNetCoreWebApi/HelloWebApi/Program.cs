var builder = WebApplication.CreateBuilder(args);

//Service (Container)
builder.Services.AddControllers(); //Controller kullanacaðýmýz için controller tanýmý yapýyorum
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger yapýsý inþa ediyoruz 
//Boþ þablonda swagger gelmez nuget package managerdan SwaggerGen ve uý'ý eklemek gerekiyor



var app = builder.Build();


if (app.Environment.IsDevelopment()) //Bu metot true yada false þeklinde döner
{
    //eðer development moddaysa uygulamanýn swagger kullanmasýna izin verdim
    app.UseSwagger();
    app.UseSwaggerUI();
}




//app.MapGet("/", () => "Hello World!"); //çalýþtýðýnda ilk olarak helloworld yazar bunu kapattýðýmýzda not found hatasý verir
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers(); //Bu attribute sayesinde controller bazlý rotalarýmýzý ve þemalarýmýzý belirleyebiliyoruz. Bunu eklemezsek hata alýrýz.

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}");

app.Run();
