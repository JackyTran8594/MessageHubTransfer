using MessageHubTransfer.Model;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace MessageHubTransfer.Hubs
{
    public class ClockServerHub : Hub<IClock>
    {
        private readonly ILogger<ClockServerHub> _logger;

        public ClockServerHub(ILogger<ClockServerHub> logger)
        {
            _logger = logger;
        }

        public async Task SendTimeToClients(DateTime dateTime)
        {
            _logger.LogInformation("======== SendTimeToClients ======== {}", dateTime);
            await Clients.All.broadCastTimeServer(dateTime);
        }
    }
}
