namespace HelloWebApi.Models
{
    public class ResponseModel //Controllerlar modelleri kullanırlar
    {
        public int HttpStatus { get; set; }
        public string Message { get; set; }
    }
}
