using MessageHubTransfer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace MessageHubTransfer.Workerservice
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;

        private HubConnection _hubConnection;

        public WorkerService(ILogger<WorkerService> logger)
        {
            _logger = logger;
            _hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7138/serverData").WithAutomaticReconnect().Build();
            _hubConnection.StartAsync();

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("Worker running at: {time}", DateTime.Now);
                //await _hubContext.Clients.All.SendAsync("getTimeServer", serverTime);
                await _hubConnection.SendAsync("sendCurrentTimeToClient", "trigger");
            }
        }
    }
}
