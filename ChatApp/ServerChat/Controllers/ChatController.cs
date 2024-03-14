using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerChat;

[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly ChatService _service;
    public ChatController(ChatService chatService){
        _service = chatService;
    }
    

    [HttpPost("register-user")]
    public IActionResult RegisterUser(UserModel model){
        if(_service.AddUserToList(model.Name)){
            // 200 status code
            return NoContent();
        }

        return BadRequest("This name is taken please choose another name");
    }
}
