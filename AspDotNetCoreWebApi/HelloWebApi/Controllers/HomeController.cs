using HelloWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{
    [ApiController] //HomeController'ın api yapısını desteklemesi amacıyla [ApiController] attribute'ünü yazarak tanım yaptım.
    [Route("api/[Controller]/[Action]")]
    public class HomeController: ControllerBase //ControllerBase'i extend aldım çünkü HomeController'ın Controller özelliklerini kazanmasını istiyorum.
    {
        [HttpGet]
        public ResponseModel GetMessage() //Otomatik olarak json formatında Serialization etmiş bir şekilde iki prop ifadeyi döner. 
        {
            //Çalıştığımız sınıf ApiController olduğu için json formatında dönüşü otomatik olarak gerçekleştiriyor.
            return new ResponseModel() 
            {
                HttpStatus = 200,
                Message = "Hello ASP .NET Core Web API"
            };
        }
        ///<summary>
        ///Serialization: 
        ///Bir nesnenin saklanacak / transfer edilecek forma dönüştürülme işlemidir. 
        /// </summary>

    }
}
