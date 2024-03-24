using MessageHubTransfer.Model;
using Microsoft.AspNetCore.SignalR;

namespace MessageHubTransfer.Hubs
{
    public class ServerDataHub: Hub
    {

        // <ThrowHubException>
        public Task ThrowException()
        {
            throw new HubException("This error will be sent to the client!");
        }
        // </ThrowHubException>

        // <OnConnectedAsync>
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("======= log message connect to serverDataHub successful ======");
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
            //_ = sendServerTimeToAllClient();  
        }
        // </OnConnectedAsync>

        // <OnDisconnectedAsync>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        // </OnDisconnectedAsync>

        [HubMethodName("sendCurrentTimeToClient")]
        public async Task sendServerTime(string trigger)
        {
            DateTime serverTime = DateTime.Now;
            await Clients.All.SendAsync("getTimeServer", serverTime);
            Console.WriteLine("======= log message ======" + serverTime);
        }

        [HubMethodName("sendNotifyStorage")]
        public async Task sendNotifyStorage(string trigger)
        {
            DateTime serverTime = DateTime.Now;
            await Clients.All.SendAsync("getTimeServer", serverTime);
            Console.WriteLine("======= log message ======" + serverTime);
        }



    }
}
