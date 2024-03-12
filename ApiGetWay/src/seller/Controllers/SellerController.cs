using Microsoft.AspNetCore.Mvc;

namespace seller.Controllers;

[ApiController]
[Route("Seller")]
public class SellerController : ControllerBase
{
    private readonly ILogger<SellerController> _logger;
    public SellerController(ILogger<SellerController> logger){
        _logger = logger;
    }

    [HttpGet]
    public IActionResult SellerGet(){
        var res = new Response {
            StatusCode = 200,
            Message = "Get Seller Api has been successfully"
        };

        return Ok(res);
    }
}

public class Response {
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;
}
