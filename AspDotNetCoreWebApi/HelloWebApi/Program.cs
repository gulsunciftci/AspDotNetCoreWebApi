var builder = WebApplication.CreateBuilder(args);

//Service (Container)
builder.Services.AddControllers(); //Controller kullanaca��m�z i�in controller tan�m� yap�yorum
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger yap�s� in�a ediyoruz 
//Bo� �ablonda swagger gelmez nuget package managerdan SwaggerGen ve u�'� eklemek gerekiyor



var app = builder.Build();


if (app.Environment.IsDevelopment()) //Bu metot true yada false �eklinde d�ner
{
    //e�er development moddaysa uygulaman�n swagger kullanmas�na izin verdim
    app.UseSwagger();
    app.UseSwaggerUI();
}




//app.MapGet("/", () => "Hello World!"); //�al��t���nda ilk olarak helloworld yazar bunu kapatt���m�zda not found hatas� verir
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers(); //Bu attribute sayesinde controller bazl� rotalar�m�z� ve �emalar�m�z� belirleyebiliyoruz. Bunu eklemezsek hata al�r�z.

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}");

app.Run();
