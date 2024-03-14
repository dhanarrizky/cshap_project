using Microsoft.AspNetCore.SignalR;

namespace ServerChat;
public class ChatHub : Hub
{
    private readonly ChatService _service;
    public ChatHub(ChatService chatService){
        _service = chatService;
    }

    public override async Task OnConnectedAsync(){
        await Groups.AddToGroupAsync(Context.ConnectionId, "Come2Chat");
        await Clients.Caller.SendAsync("UserConnected");
    }

    public override async Task OnDisconnectedAsync(Exception exception){
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Come2Chat");
        await base.OnDisconnectedAsync(exception);
    }


}
