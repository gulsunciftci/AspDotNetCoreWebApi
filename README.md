Merhaba bu repoda Asp .Net Core 6 web api projeleri oluşturacağım ve aşamalarını sizlerle paylaşacağım 👩🏻‍💻

# 📁 [hello_world_api_cli](https://github.com/gulsunciftci/AspDotNetCoreWebApi/tree/main/AspDotNetCoreWebApi/hello_world_api_cli)

* Bu proje'yi  UI aracını kullanarak oluşturdum. Peki UI nedir?
### UI: 
* Bir arayüz(user interface) aracılığı ile proje oluşturma şansı tanır.

# 📁 [hello_world_api_ui](https://github.com/gulsunciftci/AspDotNetCoreWebApi/tree/main/AspDotNetCoreWebApi/hello_world_api_ui)

* Bu projeyi komut seti yardımıyla oluşturdum. Peki CLI nedir?
### CLI:
* [Microsoft .Net Basic Commands ](https://learn.microsoft.com/en-us/dotnet/core/tools/)
* Komut seti yardımıyla proje oluşturma şansı tanır.
#### Sırasıyla yaptığım işlemler:
- Solution'ın olduğu klasöre giderek cmd yazıp yerleştim 
- cmd ekranı açılmış oldu
- yeni proje açmak için komut satırına şu komutu yazdım: dotnet new webapi -o  hello_world_api_cli
- Oluşturduğum proje visual studio arayüzünde Solution'da gözükmedi. Solution ile projeyi ilişkilendirmem gerekiyordu bunun için Solution üzerine sağ tıklayıp add dedikten sonra existing item seçeneğini seçerek proje dosyasını solution'a ekledim. 

# 📁 [HelloWebApi](https://github.com/gulsunciftci/AspDotNetCoreWebApi/tree/main/AspDotNetCoreWebApi/HelloWebApi)

* HelloWebApi projesini Asp.Net Core empty proje olarak oluşturdum.
* İlk başta proje'ye swagger implementasyonu yapılmamıştı bu yüzden daha sonra ben ekledim
* Ekleme işlemini şu şekilde yaptım: 
- İlk olarak nuget package manager'dan  SwaggerGen ve SwaggerUI paketlerini yükledim.
- Daha sonra Program.cs'e aşağıdaki kodu ekleyerek Swagger'ı implemente ettim.

```C#
builder.Services.AddSwaggerGen(); 
``` 
- Bu haliyle projemizi çalıştırırsak swagger'ı açmaz çünkü henüz swaggerla ilgili tanımım yok. Uygulamaya swagger'ı kullan dememiz gerekiyor. Bu işlemi aşağıdaki kodları Program.cs'e ekleyerek yaptım.

```C#
app.UseSwagger();
app.UseSwaggerUI();
```

- Son olarak Properties dosyasındaki launchSettings.json dosyasının profiles yazan kısmının içerisine "launchUrl": "swagger" ekledim ve Swagger implementasyonunu tamamladım.

* HelloWebApi projesi içresinde henüz Controller yok bu sebeple Controllers isminde bir dosya ekledim ve dosyaya HomeController isminde bir class ekledim. 
* Oluşturulan bu class ilk aşamada bir controller özelliği taşımıyor. HomeController'ın Controller özelliklerini kazanmasını istediğimden ötürü ControllerBase'i extend aldım.

```C#
public class HomeController: ControllerBase 
{

}
```
- HomeController'ın api yapısını desteklemesi amacıyla [ApiController] attribute'ünü yazarak tanım yaptım.

```C#
    [ApiController] 
    [Route("api/[Controller]/[Action]")]
    public class HomeController: ControllerBase 
    {

    }
```
- Proje bu aşamada yine hata verecek(404) bu yüzden program.cs'e aşağıdaki attribute'ü ekledim. Bu attribute sayesinde controller bazlı rotalarımızı ve şemalarımızı belirleyebiliyoruz. 

```C#
    app.MapControllers();
```

- Models sınıfı oluşturdum ve İçerisine ResponseModel isminde bir class ekledim. 
- Not: Controllerlar modelleri kullanırlar.

```C# 

public class ResponseModel 
{
        public int HttpStatus { get; set; }
        public string Message { get; set; }
}

```

- HomeController içerisine bir GetMessage metodu oluşturdum. Bu metot Otomatik olarak json formatında Serialization(Bir nesnenin saklanacak / transfer edilecek forma dönüştürülme işlemidir.) etmiş bir şekilde iki prop ifadeyi döner çünkü Çalıştığımız sınıf ApiController olduğu için json formatında dönüşü otomatik olarak gerçekleştiriyor.

```C#
[HttpGet]
public ResponseModel GetMessage() 
{
    
    return new ResponseModel() 
    {
        HttpStatus = 200,
        Message = "Hello ASP .NET Core Web API"
    };
}
```

- Projeyi IIS üzerinden çalıştırdığımda hata verdi. Bu durumu düzeltmek için Properties dosyasındaki launchSettings.json'a giderek IIS kısmındaki   "ASPNETCORE_ENVIRONMENT": "Development" bölümünü Production olarak değiştirdim.
```C#
"ASPNETCORE_ENVIRONMENT": "Production"
```

- Daha sonra program.cs'deki app'in hangi modda çalıştığını kontrol ettim

```C#
"ASPNETCORE_ENVIRONMENT": "Production"
```
- Eğer development moddaysa uygulamanın swagger kullanmasına izin verdim.
```C#
if (app.Environment.IsDevelopment()) //Bu metot true yada false şeklinde döner
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```
- Bunu yaparak development mod ile production modu ayırmış oldum.