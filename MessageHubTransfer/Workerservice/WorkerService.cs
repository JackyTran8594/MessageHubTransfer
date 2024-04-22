using MessageHubTransfer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace MessageHubTransfer.Workerservice
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;

        //private HubConnection _hubConnection;
        private readonly IHubContext<ClockServerHub, IClock> _clockHub;

        public WorkerService(ILogger<WorkerService> logger, IHubContext<ClockServerHub, IClock> clockHub)
        {
            _logger = logger;
            _clockHub = clockHub;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("======== ExecuteAsync broadCast data =======");
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {Time}", DateTime.Now);
                await _clockHub.Clients.All.broadCastTimeServer(DateTime.Now);
                await Task.Delay(1000);
            }
        }

    }
}
