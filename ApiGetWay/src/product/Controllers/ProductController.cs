using Microsoft.AspNetCore.Mvc;

namespace product.Controllers;

[ApiController]
[Route("Product")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    public ProductController(ILogger<ProductController> logger){
        _logger = logger;
    }

    [HttpGet]
    public IActionResult ProductGet(){
        var res = new Response{
            StatusCode = 200,
            Message = "Get Product Api has been successfully"
        };
        return Ok(res);
    }
}


public class Response {
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;
}