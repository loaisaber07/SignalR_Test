using Microsoft.AspNetCore.SignalR;
namespace SignalR_Test.Model
{
    public class ChatHub : Hub
    {
        public void sendMessage(string userName, string message)
        { 
        //save it into your own DataBase
    Clients.All.SendAsync("ReceiveMessage", userName, message);
        
        }
    }
}
