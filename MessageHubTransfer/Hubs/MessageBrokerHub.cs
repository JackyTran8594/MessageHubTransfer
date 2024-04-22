using MessageHubTransfer.Model;

using Microsoft.AspNetCore.SignalR;


namespace MessageHubTransfer.Hubs
{
    
    public sealed class MessageBrokerHub:Hub
    {
        private readonly ILogger<MessageBrokerHub> _logger;

        public MessageBrokerHub(ILogger<MessageBrokerHub> logger)
        {
            _logger = logger;
        }

        public async Task sendMessage(string user, string message)
        {
            await Clients.All.SendAsync(user, message);

        }

        public async Task senMessageToCaller(string user, string message)
        {
            await Clients.Caller.SendAsync(user, message);

        }

        public async Task SendMessageToGroup(string user, string message)
        {
            await Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);

        }
        // </HubMethods>

        // <HubMethodName>
        [HubMethodName("SendMessageToUser")]
        public async Task DirectMessage(string user, string message)
        {
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
            Console.WriteLine("======= log message connect to MessageBrokerHub successful ======");
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync(); 
        }
        // </OnConnectedAsync>

        // <OnDisconnectedAsync>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        // </OnDisconnectedAsync>

        [HubMethodName("clientMessage")]
        public async Task receviedMessageFromClient(MessageEvent message)
        {
            await Clients.All.SendAsync("serverMessage", message);
            Console.WriteLine("======= log message ======" + message.ToString());
            _logger.LogInformation("======== clientMessage ======= " + message.ToString());

        }



    }
}
