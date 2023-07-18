using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        List<Product> products = new List<Product>()
        {
                new Product(){Id=1,ProductName="Computer"},
                new Product(){Id=2,ProductName="Keyboard"},
                new Product(){Id=2,ProductName="Mouse"}


        };

        ///<summary>
        ///Bir ifade eğer readonly olarak tanımlandıysa bunun değerini iki yerde verebiliriz. Bu ifadenin değerini sadece bir kez set edebiliyoruz.
        ///1) Constructor
        ///2) Tanımlandığı yer 
        /// </summary>
        /// 

        //Dependency injection
        private readonly ILogger<ProductsController> _logger; // Loglama bir stratejidir. Yani sistemin herhangi bir ‘T’ zamanında yaptığı işlemleri adım adım kayda almasıdır. 

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger; //referans veriliyor
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            //var products = new List<Product>()
            //{
            //    new Product(){Id=1,ProductName="Computer"},
            //    new Product(){Id=2,ProductName="Keyboard"},
            //    new Product(){Id=2,ProductName="Mouse"}


            //};
            _logger.LogInformation("GetAllProducts action has been called"); //Log bilgisi düştüm. Info seviyesinde bir log. Consoledan görüntülenebilir yada debug console'undan görüntülenebilir.
            return Ok(products);
        }


        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product) //requestin bodysinden gelecek
        {

            _logger.LogWarning("Product has been created"); //warning seviyesinde bir  kaynak oluşturduğunu söylesin
            return StatusCode(201); //Created
        }



    }
}
