using Microsoft.AspNetCore.SignalR;

namespace MessageHubTransfer.Hubs
{
    public class MessageBrokerHub: Hub
    {
        public async Task sendMessage(string user, string message)
        {
            //return Clients.All.SendAsync(user, message);
            await Clients.All.SendAsync(user, message);

        }

        public async Task senMessageToCaller(string user, string message)
        {
            //return Clients.Caller.SendAsync(user, message);
            await Clients.Caller.SendAsync(user, message);

        }

        public async Task SendMessageToGroup(string user, string message)
        {
            //return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
            await Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);

        }
        // </HubMethods>

        // <HubMethodName>
        [HubMethodName("SendMessageToUser")]
        public async Task DirectMessage(string user, string message)
        {
            //return Clients.User(user).SendAsync("ReceiveMessage", user, message);
            await Clients.User(user).SendAsync("ReceiveMessage", user, message);

        }
        // </HubMethodName>

        // <ThrowHubException>
        public Task ThrowException()
        {
            throw new HubException("This error will be sent to the client!");
        }
        // </ThrowHubException>

        // <OnConnectedAsync>
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        // </OnConnectedAsync>

        // <OnDisconnectedAsync>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Group("SignalR Users").SendAsync("ReceiveMessage", "I", "disconnect");
            await base.OnDisconnectedAsync(exception);
        }
        // </OnDisconnectedAsync>


    }
}
